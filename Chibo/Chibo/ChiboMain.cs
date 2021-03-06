﻿using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Chibo.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Chibo
{
    public class ChiboMain
    {

        static ChiboDatabase database;

        public ChiboMain()
        {
            //TODO
        }

        public static ChiboDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ChiboDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ChiboSQLite.db3"));
                }
                return database;
            }
        }      
    }
}
