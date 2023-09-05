using McTools.Xrm.Connection;
using NuGet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace FlowActivationOrder
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Flow Activation Order"),
        ExportMetadata("Description", "Flow Activation Order"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAFeAAABXgFfbG56AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAABbBJREFUWIXFl1lsVFUYx//fvXfudKWFLkwXaKuGPVXoRguEasOSEFwDPpho4gsmoLYYDFQTBA1FDVsrL/qgEuMSoEiiLwShlB2CUQIFKradUqadTDvttNPZ7/18KJ2eO9MNguE8zbf+f+fec885Q8yMJzmkJ6oOQHnUQrrqsCAYsEABg01dXJJuf6Q+D/MK6GJHFkiuAvhVAHkR4bsA6iGb9nFRWtdjBSCAcNn2ARg7AcROkD4IUDUvzqh9LAAEEC51fgvwW5NpKIxvsDhzAwPjCkwMcNFWA8LWCDeDcQ0SNQ1ZPB9AQVQxYzuXZu58ZAC61LkI4Kswfi0XQPQel2RcM4J2FIPkOoCLBXcIsvQcF1lujqUxwWfIOyJyTsJEKyLFAYBLs6/Ap1QAfEZwKwjxJ+MpjPkE6II9HZJ2HyOfqgfEs7kkq2PchlfsedC1WwDMD1x++AIWLs/teziAS7YXARzPjvM25yf3d+fFDwammLQQCB4QtZDOJwamZJ2qxTNBq/V+OROtBGGGo8c1WNOPp46pSRUjzWgVl2ScGE1nzI1oWVrPzKJU1w2zpC0AMEuMabrW19ntKMx0uDe2meIWgCgHAMBATIx6o8LZ6zqmJoXzpxHmA5g8wLb+hk1L02kvAFNkzBcI3ul02s2vybPVQlPmmsi4iWSzquuGvjXJvKbVagvm5WR+FZkftQir3Y0biKhuNPGAFrJ29nQlrlPmdhcqmcWRcQDw+f29XbLiE30WGSoR6lqttk3jAlT3ny4B88GInJ6brsTTP7Zl/+4h38ItMWWHF8mWQjHBrviajyRZL/6U3LJXpsDq3THpcWL8aQUpAECE/W0dHSVizPgKSD4AsByeMUtNXzfnpAyElOcBoK1t4RvTpuIdseRcnONck7mvFEPrZNE6Sb3nIaloOJ4poyueMOeBKUOX9gEoi3oC21ynCwAW6Rzf/TuzfiCkTA+L+VDTo+PWCDDX3zK77ACGoc3FqX0viYBTJf4GoAHBVdre3hneNcMARPLLhofBqOnR1RoAzcO+AUZCiR35B/pxvk/j68e98u7bzuRdALThnIzYwAyhTdPNgeAuALvF3hrjlSgAJn7WAKBr9VyQ4YHE60HoE4ql/W4sWWin/EqnfqW+Oa42oEl3huMy6TmKxD4ATsjSei7P9UHHr4bekj43CgAYWigPhv5Z8gtWAODirL+hSSsBjL4DSnLQ7ZdcgkdJUYN/QueK4TPA4+ltMdQwWaIACBQUIbfYT8SH88ssVzcnqxWViTinGPMA0kiRdVl0rc60vcllWX8N26pqiTHoA95RAPiOkENKgloqFq2dk9ryfiKKbmdw75EUOvvuFJxXJPwhM6yJZhZvR9689LJWsVY2+8pFWwJahN/DWHTeMDNdqhTNciDEwDmZkF5g5mWbE7Ck2UK/fFhsO0XgtBF0nN0O6OJkiGHYgHRQYxRAwOs7CiD8Lgm85iN340YDFPiQaBH4cxOoyuDT6XvRtt67XwVgheDq9cYq4UUZBvhy+spBAF8Y5JjrqgfO7NnaezIJALxu18+AsA8AU1/vy52ZpKuXMTTrpu4p8YcB4G5XV5q13VbLTHuMk8D+eWlp7jCweBxvwDVTyoD7AoDCiKJBBjUEQv4b3p7+3Cpz8VoTy4bttl8KOAISX0wNqV0A5QFYiqgLLF3pcdiWFhQUhBdy1H2g2n02Daw3AJiHUYajz3kG/lD8VrUsXwapo+WMOhjXwaZVubnGK3vUabgrYZnDHIwpZeCH0fqkJU9bLsUonk/9Z293aP3/TEoadEiiUHmkODDBpfRjV0OhLqOSmFYxkCqEQl6/76jT6WzcEbvcS4y3GVQCsHiE9xL4N5b4YG529uWxNCb1x2QHIAW9pzI0v5KuyJpnMDGmfS9KvWJOU1OTak5MmWVi3cwsOXNypreO1e+hAf7P8cT/Hf8Hzo1P85adLY0AAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class FlowActivationOrderPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public FlowActivationOrderPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}