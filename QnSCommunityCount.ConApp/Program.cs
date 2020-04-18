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
        static string SaEmail => "SysAdmin@QnSCommunityCount.gmx.at";
        static string SaPwd => "Sys2189!Admin";

        static string AaUser => "AppAdmin";
        static string AaEmail => "AppAdmin@QnSCommunityCount.gmx.at";
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
                var appLogin = await appAccountManager.LogonAsync(AaEmail, AaPwd);

                await GenerateMarokkoAsync(appLogin.SessionToken);
                await appAccountManager.LogoutAsync(appLogin.SessionToken);
                //await InitAppAccessAsync();
                //await AddAppAccessAsync(AaUser, AaEmail, AaPwd, AaEnableJwt, AaRole);

                //await AddAppAccessAsync("schueler1", "schueler1@gmx.com", "Passme1234!", AaEnableJwt);
                //await AddAppAccessAsync("schueler2", "schueler2@gmx.com", "Passme1234!", AaEnableJwt);
                //await AddAppAccessAsync("schueler3", "schueler3@gmx.com", "Passme1234!", AaEnableJwt);

                //var rmLogin = await rmAccountManager.LogonAsync("schueler1@gmx.com", "Passme123!");
                //var appLogin = await appAccountManager.LogonAsync(rmLogin.JsonWebToken);

                //await appAccountManager.LogoutAsync(appLogin.SessionToken);
                //await rmAccountManager.LogoutAsync(rmLogin.SessionToken);
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

            entity.Identity.Name = user;
            entity.Identity.Email = email;
            entity.Identity.Password = pwd;
            entity.Identity.EnableJwtAuth = enableJwtAuth;

            foreach (var item in roles)
            {
                var role = entity.CreateRole();

                role.Designation = item;
                entity.AddRole(role);
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
