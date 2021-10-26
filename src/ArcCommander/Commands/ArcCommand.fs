﻿namespace ArcCommander.Commands

open Argu 
open ArcCommander.CLIArguments

type ArcCommand =

    | [<AltCommandLine("-p")>][<Unique>] WorkingDir of working_directory : string
    | [<AltCommandLine("-v")>][<Unique>] Verbosity of verbosity : int
    | [<CliPrefix(CliPrefix.None)>] Init of init_args : ParseResults<ArcInitArgs>
    | [<CliPrefix(CliPrefix.None)>] Export of export_args : ParseResults<ArcExportArgs>
    | [<AltCommandLine("sync")>][<CliPrefix(CliPrefix.None)>][<SubCommand()>] Update
    | [<AltCommandLine("i")>][<CliPrefix(CliPrefix.None)>] Investigation of verb_and_args : ParseResults<InvestigationCommand>
    | [<AltCommandLine("s")>][<CliPrefix(CliPrefix.None)>] Study of verb_and_args : ParseResults<StudyCommand>
    | [<AltCommandLine("a")>][<CliPrefix(CliPrefix.None)>] Assay of verb_and_args : ParseResults<AssayCommand>
    | [<AltCommandLine("config")>][<CliPrefix(CliPrefix.None)>] Configuration of verb_and_args : ParseResults<ConfigurationCommand>
    | [<CliPrefix(CliPrefix.None)>] Git of verb_and_args : ParseResults<GitCommand>

    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | WorkingDir    _   -> "Set the base directory of your ARC"
            | Verbosity     _   -> "Set the amount of additional printed information: 0 -> No information, 1 (Default) -> Basic Information, 2 -> Additional information"
            | Init          _   -> "Initialize basic folder structure"
            | Update        _   -> "Synchronize ISA and and other items"
            | Export        _   -> "Exports the full arc to a json object"
            | Investigation _   -> "Investigation file functions"
            | Study         _   -> "Study functions"
            | Assay         _   -> "Assay functions"
            | Configuration _   -> "Configuration editing"
            | Git           _   -> "Git related"