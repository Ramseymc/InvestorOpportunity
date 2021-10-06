using InvestorLibrary.Interest;
using InvestorLibrary.Investment;
using InvestorLibrary.Investor;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Opportunity;
using InvestorLibrary.OpportunityCategory;
using InvestorLibrary.Shared;
using InvestorLibrary.TransactionType;
using InvestorLibrary.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary
{

    public static class ContainerConfig
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static string DBConnection;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDataAccessRepository, DataAccessRepository>();
            
            services.AddScoped<ISharedRepository, SharedRepository>();
            services.AddScoped<IInvestmentRepository, InvestmentRepository>();
            services.AddScoped<IInvestorRepository, InvestorRepository>();
            services.AddScoped<IInvestPledgeRepository, InvestPledgeRepository>();
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IOpportunityCategoryRepository, OpportunityCategoryRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            ServiceProvider = services.BuildServiceProvider();
        }



        [Conditional("DEBUG")]
        private static void IsDebugCheck(ref bool isDebug)
        {
            isDebug = true;
        }


        public static void GetDBConnection()
        {
            bool isDebug = false;

            IsDebugCheck(ref isDebug);

            if (isDebug)
            {
                DBConnection = ConfigurationManager.ConnectionStrings["Development"].ConnectionString;
            }
            else
            {
                DBConnection = ConfigurationManager.ConnectionStrings["Production"].ConnectionString;
            }
            
        }

    }
}

