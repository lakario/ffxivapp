﻿// FFXIVAPP.Client
// PlayerRegEx.cs
// 
// © 2013 Ryan Wilson

#region Usings

using System.Text.RegularExpressions;
using FFXIVAPP.Common.RegularExpressions;
using SmartAssembly.Attributes;

#endregion

namespace FFXIVAPP.Client.RegularExpressions
{
    [DoNotObfuscate]
    internal static class PlayerRegEx
    {
        //ENGLISH REGULAR EXPRESSIONS
        public static Regex DamageEn = new Regex(@"^ ⇒ (?<block>Blocked! )?(?<parry>Parried! )?(?<crit>Critical! )?((T|t)he )?(?<target>.+) takes? (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?damage\.$", SharedRegEx.DefaultOptions);

        public static Regex DamageAutoEn = new Regex(@"^(?! ⇒)(?<block>Blocked! )?(?<parry>Parried! )?(?<crit>Critical! )?(?<source>You|.+) hits? ((T|t)he )?(?<target>.+) for (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?damage\.$", SharedRegEx.DefaultOptions);

        public static Regex ResistEn = new Regex(@"^(?! ⇒)(?<resist>(Full|Partial|Half) resist! )(?<source>You|.+) takes? ((?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?|no )damage\.$", SharedRegEx.DefaultOptions);

        public static Regex FailedEn = new Regex(@"^( ⇒ )?The attack miss(es)?( ((T|t)he )?(?<target>.+))?\.$", SharedRegEx.DefaultOptions);

        public static Regex FailedAutoEn = new Regex(@"^(?! ⇒)(?<source>You|.+) miss(es)? ((T|t)he )?(?<target>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ActionsEn = new Regex(@"^(?<source>You|.+) (use|cast)s? (?<action>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ItemsEn = new Regex(@"^(?<source>You|.+) uses? (an? |the )?(?<item>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex CureEn = new Regex(@"( ⇒ )?(?<crit>Critical! )?((T|t)he )?(?<target>You|.+) recovers? (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?(?<type>\w+)\.$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialGainEn = new Regex(@"^( ⇒ )?(?<target>You|.+) gains? the effect of (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialLoseEn = new Regex(@"^( ⇒ )?(?<target>You|.+) loses? the effect of (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalGainEn = new Regex(@"^( ⇒ )?(?<target>You|.+) suffers? the effect of (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalLoseEn = new Regex(@"^( ⇒ )?(?<target>You|.+) recovers? from the effect of (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ObtainsEn = new Regex(@"^(?<source>You|.+) obtains? (an? |the )?(?<item>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex DefeatsEn = new Regex(@"^((?<source>You|.+) defeats? ((T|t)he )?(?<target>.+)|((T|t)he )?(?<target>.+) is defeated)\.$", SharedRegEx.DefaultOptions);

        //FRENCH REGULAR EXPRESSIONS
        public static Regex DamageFr = new Regex(@"^ ⇒ (?<parry>Parade ?! )?(?<block>Blocage ?! )?(?<crit>Critique ?! )?(L[aes] |[LEAD]')?(?<target>.+) subit (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?points? de dégâts?\.$", SharedRegEx.DefaultOptions);

        public static Regex DamageAutoFr = new Regex(@"^(?! ⇒)(?<parry>Parade ?! )?(?<block>Blocage ?! )?(?<crit>Critique ?! )?(?<source>Vous|.+) infligez? \w+ (l[aes] |[lead]')?(?<target>.+) (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?points? de dégâts?\.$", SharedRegEx.DefaultOptions);

        public static Regex ResistFr = new Regex(@"^(?! ⇒)(?<resist>(Résistance totale|Résistance partielle|Semi résistance)! )(L[aes] |[LEAD]')?(?<target>.+) (subi(t|ssez?)? (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?points? de |ne subi(t|ssez?)? aucun )dégâts?\.$", SharedRegEx.DefaultOptions);

        public static Regex FailedFr = new Regex(@"^( ⇒ )?L'attaque manquez? (l[aes] |[lead]')?(?<target>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex FailedAutoFr = new Regex(@"^(?! ⇒)(?<source>Vous|.+) manquez? (l[aes] |[lead]')?(?<target>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ActionsFr = new Regex(@"^(?<source>Vous|.+) (utilise|lance)z? (?<action>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ItemsFr = new Regex(@"^(?<source>Vous|.+) utilisez? une? (?<item>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex CureFr = new Regex(@"^( ⇒ )?(?<crit>Critique ?! )?(?<target>Vous|.+) récup(é|è)rez? (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?(?<type>\w+)\.$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialGainFr = new Regex(@"^( ⇒ )?(?<target>Vous|.+) bénéficiez? de l'effet (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialLoseFr = new Regex(@"^( ⇒ )?(?<target>Vous|.+) perd(ez?)? l'effet (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalGainFr = new Regex(@"^( ⇒ )?(?<target>Vous|.+) subi(t|ssez?) l'effet (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalLoseFr = new Regex(@"^( ⇒ )?(?<target>Vous|.+) (perd(ez?)?|ne subi(t|ssez?)) plus l'effet (?<status>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ObtainsFr = new Regex(@"^((?<source>Vous) obtenez|(?<source>.+) obtient)( une?| de la| l[aes])? (?<item>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex DefeatsFr = new Regex(@"^(((?<source>Vous) avez|(?<source>.+) a) vaincu (l[aes] |[lead]')?(?<target>.+)|(L[aes] |[LEAD]')?(?<target>.+) s'effondre)\.$", SharedRegEx.DefaultOptions);

        //JAPANESE REGULAR EXPRESSIONS
        public static Regex DamageJa = new Regex(@"^ ⇒ (?<crit>クリティカル！ )?(?<target>.+)に(?<block>ブロックした！ )?(?<parry>受け流した！ )?(?<amount>\d+) ?(\((?<modifier>.\d+)%\) ?)?ダメージ。$", SharedRegEx.DefaultOptions);

        public static Regex DamageAutoJa = new Regex(@"^(?<source>.+)の攻撃( ⇒ )?(?<crit>クリティカル！ )?(?<target>.+)に(?<block>ブロックした！ )?(?<parry>受け流した！ )?(?<amount>\d+) ?(\((?<modifier>.\d+)%\) ?)?ダメージ。$", SharedRegEx.DefaultOptions);

        public static Regex ResistJa = new Regex(@"^( ⇒ )?(?<target>.+)は((?<resist>レジストした！)|(?<resist>クォータレジストした！ )?(?<resist>ハーフレジストした！ )?(?<amount>\d+) ?(\((?<modifier>.\d+)%\) ?)?ダメージ。)$", SharedRegEx.DefaultOptions);

        public static Regex FailedJa = new Regex(@"^( ⇒ )?(?<target>.+)にミス！$", SharedRegEx.DefaultOptions);

        public static Regex FailedAutoJa = new Regex(@"^(?<source>.+)の攻撃( ⇒ )?(?<target>.+)にミス！$", SharedRegEx.DefaultOptions);

        public static Regex ActionsJa = new Regex(@"^(?<source>.+)の「(?<action>.+)」$", SharedRegEx.DefaultOptions);

        public static Regex ItemsJa = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex CureJa = new Regex(@"^( ⇒ )?(?<crit>クリティカル！ )?(?<source>.+)は(?<amount>\d+) ?(\((?<modifier>.\d+)%\) ?)?(?<type>\w+)回復。$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialGainJa = new Regex(@"^( ⇒ )?(?<target>.+)に「(?<status>.+)」の効果。$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialLoseJa = new Regex(@"^( ⇒ )?(?<target>.+)に「(?<status>.+)」が切れた。$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalGainJa = new Regex(@"^( ⇒ )?(?<target>.+)に「(?<status>.+)」の効果。$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalLoseJa = new Regex(@"^( ⇒ )?(?<target>.+)に「(?<status>.+)」が切れた。$", SharedRegEx.DefaultOptions);

        public static Regex ObtainsJa = new Regex(@"^(?<source>.+)は「(?<item>.+)」(?<amount>×.+)?を入手した。'$", SharedRegEx.DefaultOptions);

        public static Regex DefeatsJa = new Regex(@"^((?<source>.+)は(?<target>.+)を倒した。|(?<target>.+)は、力尽きた。)$", SharedRegEx.DefaultOptions);

        //GERMAN REGULAR EXPRESSIONS
        public static Regex DamageDe = new Regex(@"^ ⇒ (?<block>Geblockt! ?)?(?<parry>Pariert! ?)?(?<crit>Kritischer Treffer! ?)?(D(u|einer|(i|e)r|ich|as|ie|en) )?(?<target>.+) erleides?t (nur )?(?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?Punkte? (Schaden|reduziert)\.$", SharedRegEx.DefaultOptions);

        public static Regex DamageAutoDe = new Regex(@"^(?! ⇒)(?<block>Geblockt! ?)?(?<parry>Pariert! ?)?(?<crit>Kritischer Treffer! ?)?(?<source>Du|.+) triffs?t (d(u|einer|(i|e)r|ich|as|ie|en) )?(?<target>.+) und verursachs?t (?<amount>\d+) ?(\((?<modifier>.\d+)%\) )?Punkte? (Schaden|reduziert)\.$", SharedRegEx.DefaultOptions);

        public static Regex ResistDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex FailedDe = new Regex(@"^( ⇒ )?Die Attacke verfehlt?( (d(u|einer|(i|e)r|ich|as|ie|en) )?(?<target>.+))?\.$", SharedRegEx.DefaultOptions);

        public static Regex FailedAutoDe = new Regex(@"^(?! ⇒)(?<source>Du|.+) verfehls?t (d(u|einer|(i|e)r|ich|as|ie|en) )?(?<target>.+)\.$", SharedRegEx.DefaultOptions);

        public static Regex ActionsDe = new Regex(@"^(?<source>Du|.+) (setzt (?<action>.+) ein|wirks?t (?<action>.+))\.$", SharedRegEx.DefaultOptions);

        public static Regex ItemsDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex CureDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialGainDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex BeneficialLoseDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalGainDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex DetrimentalLoseDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex ObtainsDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);

        public static Regex DefeatsDe = new Regex(@"^\.$", SharedRegEx.DefaultOptions);
    }
}