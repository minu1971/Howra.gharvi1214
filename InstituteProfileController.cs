using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_mvc.Models;

namespace test_mvc.Controllers
{
    public class InstituteProfileController : Controller
    {
        // GET: InstituteProfile
        public ActionResult DisplayInstitute()
        {
           // var institutes = new List<InstituteProfileModel>();
           var institutes = InstitutesListing();
            return View(institutes);
        }



        public List<InstituteProfileModel> InstitutesListing()
        {


            var result = new List<InstituteProfileModel>();
            try
            {
                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();

                        {

                            result = db.Query<InstituteProfileModel>
                                    ("Select * from Tbl_Institute order by Institute_Id  desc", new
                                    {

                                    }).ToList();



                        }

                    }
                    catch (Exception ex)
                    {


                    }
                    finally
                    {
                        db.Close();
                    }
                }

            }
            catch (Exception ex)
            {


                return result;
            }
            return result;
        }



    }
}