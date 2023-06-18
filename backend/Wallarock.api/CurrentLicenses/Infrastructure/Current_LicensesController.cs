using Microsoft.AspNetCore.Mvc;
using License.viewer.api.Models;


namespace License.viewer.api.Controllers
{
    [ApiController]
    [Route("current_licenses_list")]

    public class Current_LicensesController : ControllerBase
    {
        [HttpGet]

        public dynamic listarCliente()
        {
            List<Current_Licenses> CurrentLicenses = new List<Current_Licenses>
            {
                new Current_Licenses(

                    "000000-001",
                    "0C-54-A5-00-4E-43",
                    "31/12/2018",
                    "12/04/2018 16:09:04",
                    "740138905",
                    "0000015-292",
                    "ZKCM",
                    "IK",
                    true,
                    "P-UPM",
                    "",
                    "trunck",
                    "Prod",
                    "MORE INFO"
                ),
                new Current_Licenses(

                    "000000-001",
                    "0C-54-A5-00-4E-43",
                    "31/12/2018",
                    "12/04/2018 16:09:04",
                    "740138905",
                    "0000015-292",
                    "ZKCM",
                    "IK",
                    true,
                    "P-UPM",
                    "",
                    "trunck",
                    "Prod",
                    "MORE INFO"
                ),
                new Current_Licenses(
                    "000000-002",
                    "0C-54-A5-00-4E-43",
                    "31/12/2018",
                    "12/04/2018 16:09:04",
                    "740138905",
                    "0000015-292",
                    "ZKCM",
                    "IK",
                    true,
                    "P-UPM",
                    "",
                    "trunck",
                    "Prod",
                    "MORE INFO"
                ),
                new Current_Licenses(

                    "000000-003",
                    "0C-54-A5-00-4E-43",
                    "31/12/2018",
                    "12/04/2018 16:09:04",
                    "740138905",
                    "0000015-292",
                    "ZKCM",
                    "IK",
                    true,
                    "P-UPM",
                    "",
                    "trunck",
                    "Prod",
                    "MORE INFO"
                )
            };
            return CurrentLicenses;
        }
    }
}
