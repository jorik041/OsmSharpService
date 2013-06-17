﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace OsmSharpService.SelfHost
{
    /// <summary>
    /// Program containing the entry point of the application.
    /// </summary>
    partial class Program
    {
        /// <summary>
        /// Command Line options will be parsed.
        /// </summary>
        private sealed class Options
        {
            /// <summary>
            /// The filename.
            /// </summary>
            [Option('f', "file", Required = true, HelpText = "The OSM-file to load.")]
            public string File { get; set; }


            /// <summary>
            /// The hostname.
            /// </summary>
            [Option('h', "host", HelpText = "The hostname to host the service.")]
            public string Hostname { get; set; }

            //
            // Marking a property of type IParserState with ParserStateAttribute allows you to
            // receive an instance of ParserState (that contains a IList<ParsingError>).
            // This is equivalent from inheriting from CommandLineOptionsBase (of previous versions)
            // with the advantage to not propagating a type of the library.
            //
            [ParserState]
            public IParserState LastParserState { get; set; }

            /// <summary>
            /// Returns the autogenerated usage description.
            /// </summary>
            /// <returns></returns>
            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            }
        }
    }
}