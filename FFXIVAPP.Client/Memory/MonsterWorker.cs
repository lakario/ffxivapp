﻿// FFXIVAPP.Client
// MonsterWorker.cs
// 
// © 2013 Ryan Wilson

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using FFXIVAPP.Client.Helpers;
using FFXIVAPP.Common.Core.Memory;
using FFXIVAPP.Common.Core.Memory.Enums;
using NLog;
using SmartAssembly.Attributes;

namespace FFXIVAPP.Client.Memory
{
    [DoNotObfuscate]
    internal class MonsterWorker : INotifyPropertyChanged, IDisposable
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Property Bindings

        #endregion

        #region Declarations

        private readonly Timer _scanTimer;
        private bool _isScanning;

        #endregion

        public MonsterWorker()
        {
            _scanTimer = new Timer(100);
            _scanTimer.Elapsed += ScanTimerElapsed;
        }

        #region Timer Controls

        /// <summary>
        /// </summary>
        public void StartScanning()
        {
            _scanTimer.Enabled = true;
        }

        /// <summary>
        /// </summary>
        public void StopScanning()
        {
            _scanTimer.Enabled = false;
        }

        #endregion

        #region Threads

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void ScanTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isScanning)
            {
                return;
            }
            _isScanning = true;
            Func<bool> scannerWorker = delegate
            {
                if (MemoryHandler.Instance.SigScanner.Locations.ContainsKey("GAMEMAIN"))
                {
                    if (MemoryHandler.Instance.SigScanner.Locations.ContainsKey("CHARMAP"))
                    {
                        try
                        {
                            var monsterEntries = new List<ActorEntity>();
                            var npcEntries = new List<ActorEntity>();
                            var pcEntries = new List<ActorEntity>();
                            for (uint i = 0; i <= 1000; i += 4)
                            {
                                var characterAddress = (uint) MemoryHandler.Instance.GetInt32(MemoryHandler.Instance.SigScanner.Locations["CHARMAP"] + i);
                                if (characterAddress == 0)
                                {
                                    continue;
                                }
                                var actor = MemoryHandler.Instance.GetStructure<Structures.NPCEntry>(characterAddress);
                                var name = MemoryHandler.Instance.GetString(characterAddress, 48);
                                var entry = ActorEntityHelper.ResolveActorFromMemory(actor, name);
                                if (MemoryHandler.Instance.SigScanner.Locations.ContainsKey("MAP"))
                                {
                                    try
                                    {
                                        entry.MapIndex = MemoryHandler.Instance.GetUInt32(MemoryHandler.Instance.SigScanner.Locations["MAP"]);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                if (i == 0)
                                {
                                    if (MemoryHandler.Instance.SigScanner.Locations.ContainsKey("TARGET"))
                                    {
                                        var targetAddress = MemoryHandler.Instance.SigScanner.Locations["TARGET"];
                                        if (targetAddress > 0)
                                        {
                                            var targetInfo = MemoryHandler.Instance.GetStructure<Structures.Target>(targetAddress);
                                            entry.TargetID = (int) targetInfo.CurrentTargetID;
                                        }
                                    }
                                }
                                if (MemoryHandler.Instance.SigScanner.Locations.ContainsKey("MAP"))
                                {
                                    try
                                    {
                                        entry.MapIndex = MemoryHandler.Instance.GetUInt32(MemoryHandler.Instance.SigScanner.Locations["MAP"]);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                                if (!entry.IsValid)
                                {
                                    continue;
                                }
                                switch (entry.Type)
                                {
                                    case Actor.Type.Monster:
                                        monsterEntries.Add(entry);
                                        break;
                                    case Actor.Type.NPC:
                                        npcEntries.Add(entry);
                                        break;
                                    case Actor.Type.PC:
                                        pcEntries.Add(entry);
                                        break;
                                    default:
                                        npcEntries.Add(entry);
                                        break;
                                }
                            }
                            if (monsterEntries.Any())
                            {
                                AppContextHelper.Instance.RaiseNewMonsterEntries(monsterEntries);
                            }
                            if (npcEntries.Any())
                            {
                                AppContextHelper.Instance.RaiseNewNPCEntries(npcEntries);
                            }
                            if (pcEntries.Any())
                            {
                                AppContextHelper.Instance.RaiseNewPCEntries(pcEntries);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                _isScanning = false;
                return true;
            };
            scannerWorker.BeginInvoke(delegate { }, scannerWorker);
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            _scanTimer.Elapsed -= ScanTimerElapsed;
        }

        #endregion
    }
}