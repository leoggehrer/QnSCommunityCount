using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QnSCommunityCount.Contracts.Persistence.Account;
using AccountManager = QnSCommunityCount.Adapters.Modules.Account.AccountManager;

namespace QnSCommunityCount.ConApp
{
    // Search pattern for async calls without ConfigAwait: (?=\bawait\b(?!.*\bConfigureAwait\b))
    class Program
    {
        static string SaUser => "SysAdmin";
        static string SaEmail => "SysAdmin.QnSCommunityCount@gmx.at";
        static string SaPwd => "Sys2189!Admin";

        static string AaUser => "AppAdmin";
        static string AaEmail => "AppAdmin.QnSCommunityCount@gmx.at";
        static string AaPwd => "App2189!Admin";
        static string AaRole => "AppAdmin";
        static bool AaEnableJwt => true;

        static async Task Main(string[] args)
        {
            await Task.Run(() => Console.WriteLine("QnSCommunityCount"));

            var rmAccountManager = new AccountManager
            {
//                BaseUri = "https://localhost:5001/api",
                BaseUri = "https://localhost:5001/api",
                Adapter = Adapters.AdapterType.Service,
            };
            var appAccountManager = new AccountManager
            {
                BaseUri = "https://localhost:5001/api",
                Adapter = Adapters.AdapterType.Controller,
            };

            Adapters.Factory.BaseUri = "https://localhost:5001/api";
            Adapters.Factory.Adapter = Adapters.AdapterType.Controller;

            try
            {
                //await InitAppAccessAsync();
                //await AddAppAccessAsync(AaUser, AaEmail, AaPwd, AaEnableJwt, AaRole);

                var appLogin = await appAccountManager.LogonAsync(AaEmail, AaPwd);

                await GenerateMarokkoAsync(appLogin.SessionToken);
                await appAccountManager.LogoutAsync(appLogin.SessionToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {MethodBase.GetCurrentMethod().Name}: {ex.Message}");
            }
            Console.WriteLine("Press any key to end!");
            Console.ReadKey();
        }
        private static async Task InitAppAccessAsync()
        {
            await Logic.Modules.Account.AccountManager.InitAppAccessAsync(SaUser, SaEmail, SaPwd, true);
        }
        private static async Task AddAppAccessAsync(string user, string email, string pwd, bool enableJwtAuth, params string[] roles)
        {
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd);
            using var ctrl = Adapters.Factory.Create<Contracts.Business.Account.IAppAccess>(login.SessionToken);
            var entity = await ctrl.CreateAsync();

            entity.FirstItem.Name = user;
            entity.FirstItem.Email = email;
            entity.FirstItem.Password = pwd;
            entity.FirstItem.EnableJwtAuth = enableJwtAuth;

            foreach (var item in roles)
            {
                var role = entity.CreateSecondItem();

                role.Designation = item;
                entity.AddSecondItem(role);
            }
            await ctrl.InsertAsync(entity);
            await accMngr.LogoutAsync(login.SessionToken);
        }
        private static async Task GenerateMarokkoAsync(string sessionToken)
        {
            Adapters.Factory.Adapter = Adapters.AdapterType.Controller;
            using var ctrl = Adapters.Factory.Create<Contracts.Business.App.ICommunityCosts>(sessionToken);
            var communityCosts = await ctrl.CreateAsync();
//            boBill.Bill.Date = DateTime.Now;
            communityCosts.CostCollection.Designation = $"Marokko 2020-REST-{DateTime.Now}";
            communityCosts.CostCollection.Description = "Demo";
            communityCosts.CostCollection.Members = "Gerhard,Robert";
            communityCosts.CostCollection.Currency = "EUR";
            for (int i = 0; i < 5; i++)
            {
                var costRecord = communityCosts.CreateCostRecord();

                costRecord.Designation = $"Kosten: {DateTime.Now}";
                costRecord.Amount = 10 * (i + 1);
                costRecord.Member = i % 2 == 0 ? "Robert" : "Gerhard";
                communityCosts.AddCostRecord(costRecord);
            }
            await ctrl.InsertAsync(communityCosts);
        }
    }
}
