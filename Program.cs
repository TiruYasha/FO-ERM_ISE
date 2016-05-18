using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FO_ERM_ISE.Forms;
using AutoMapper;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperConfiguration>();
            });

             mapper = config.CreateMapper();
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<DataModel, DatamodelDTO>());

             Application.Run(new DataModelForm());
        }

        public static IMapper mapper { get; set; } 
    }
}
