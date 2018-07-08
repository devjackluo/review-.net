using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder{

    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root) {

            //get path of node modules and create a file provider with it
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);

            //create a staticfileoptions and change these values in it.
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;

            //now you can use static files from the options
            app.UseStaticFiles(options);
            return app;
        }

    }

}
