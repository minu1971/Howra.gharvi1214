using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using test_mvc.Models;

namespace test_mvc.Controllers
{
    public class InstituteController : Controller
    {
        readonly string _conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        int updateid;
        int instituteid = 0;
        // GET: /Institute/Register

        public ActionResult InstituteIndex(int Id=0)
        {

            InstituteViewModels model = new InstituteViewModels();
            if (Id > 0)
            {
              
                model=new InstituteCRUD().GetInstitute(Id);
               
                
            }
          
      
            return View("InstituteIndex", model);
        }

        //
        // POST: /Institute/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InstituteIndex(InstituteViewModels model)
        {
           

            
               
            if (ModelState.IsValid)
            {
              
                model.CreatedDate = DateTime.Now;
                 

                    if (model.Institute_Id > 0)
                    {

                      new InstituteCRUD().UpdateInstituteRecord(model);

                        if (model.Campus)
                        {
                            return RedirectToAction("Campus", new { InstituteId = model.Institute_Id, InstituteName = model.Name });
                        }
                        else
                        {
                            return RedirectToAction("DisplayInstitute", "InstituteProfile");
                        }
                    }
                
                    else
                    {
                        instituteid =new InstituteCRUD().AddDataInstitute(model);
                        
                         if (model.Campus)
                          {
                        return RedirectToAction("Campus", new { InstituteId = instituteid, InstituteName = model.Name });
                          }
                         else
                          {
                        return RedirectToAction("InstituteIndex", "Institute");
                          }
                    }
            }

            
            return RedirectToAction("InstituteIndex", "Institute");
        }


        //public bool UpdateInstituteRecord(InstituteViewModels model)
        //{
        //    try
        //    {
        //        var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
        //        using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
        //        {
        //            try
        //            {
        //                db.Open();
        //                string sql = "Update  [Tbl_Institute] set Name=@Name,Url=@Url,Phone=@Phone,Email=@Email,CreatedBy= @CreatedBy where Institute_Id=@Institute_Id";
        //                var update = db.Execute(sql, new
        //                {
        //                    Name = model.Name,
        //                    Url = model.Url,
        //                    Phone = model.Phone,
        //                    Email = model.Email,
        //                    CreatedBy = model.CreatedBy,
        //                    Institute_Id = model.Insitute_Id

        //                });

        //                db.Close();

        //            }
        //            catch (Exception ex)
        //            {

        //                return false;
        //            }
        //            finally
        //            {
        //                db.Close();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        return false;
        //    }
        //    return true;
        //}




        //public InstituteViewModels GetInstitute(int id = 0)
        //{
        //    var result = new InstituteViewModels();
        //    try
        //    {
        //        var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
        //        using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
        //        {
        //            try
        //            {
        //                db.Open();

        //                {

        //                    result = db.Query<InstituteViewModels>
        //                            ("Select  * from Tbl_Institute where Institute_Id=@Id order by Institute_Id  desc", new
        //                            {
        //                                Id = id
        //                            }).FirstOrDefault();

        //                    result.Insitute_Id = id;

        //                }

        //            }
        //            catch (Exception ex)
        //            {


        //            }
        //            finally
        //            {
        //                db.Close();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {


        //        return result;
        //    }
        //    return result;
        //}



        //public int AddDataInstitute(InstituteViewModels model)
        //{
        //    var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
        //    using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
        //    {
        //        try
        //        {
        //            db.Open();

        //            string sql = "INSERT INTO Tbl_Institute(Name,Url,Phone,Email,CreatedBy,CreatedDate) values(@Name,@Url,@Phone,@Email,@CreatedBy,@CreatedDate)SELECT CAST(SCOPE_IDENTITY() AS INT)";
        //            var returnid = db.Query<int>(sql, model).SingleOrDefault();


        //            db.Close();

        //            return returnid;

        //        }
        //        catch (Exception ex)
        //        {

        //            return 0;
        //        }
        //        finally
        //        {
        //            db.Close();
        //        }

        //    }
        //}

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        new 
        
        public JsonResult DeleteNotes(string NotesBoardID = "")
        {
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("Update _TblNotesBoard Set NotesBoardStatus=0 where NotesBoardID=@NotesBoardID", conn);
            cmd.Parameters.Add(new SqlParameter("@NotesBoardID", SqlDbType.NVarChar) { Value = NotesBoardID });
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateInstitute(InstituteViewModels obj)
        {

            //Url, Phone, Email, CreatedBy
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("Update Tbl_Institute Set Name=@Name,Url=@Url,Phone=@Phone,Email=@Email,CreatedBy=@CreatedBy where Institute_Id=@Institute_Id", conn);
            cmd.Parameters.Add(new SqlParameter("@Institute_Id", SqlDbType.NVarChar) { Value = obj.Institute_Id });
            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = obj.Name });
            cmd.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar) { Value = obj.Url });
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = obj.Phone });
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = obj.Email });
            cmd.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar) { Value =obj.CreatedBy});
            conn.Open();
             cmd.ExecuteNonQuery();
            conn.Close();
            return View();
        }
        

        // GET: /Campus/Register

        public ActionResult Campus(int InstituteId = 0, string InstituteName = "",int Id=0)
        {

            CampusViewModel model = new CampusViewModel();
            ViewBag.City = new SelectList(Enum.GetValues(typeof(city)).Cast<city>().OrderBy(k2 => GetEnumDescription((city)k2)).ToDictionary(k2 => (int)k2, v => v.ToString()), "Key", "Value");


            if (InstituteId > 0 )
            {
                model = new InstituteCRUD().GetCampus(InstituteId, InstituteName);
            }

            return View("Campus", model);
        }
        

        // POST: /Campus/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Campus(CampusViewModel model)
        {
            var campusid=0;

                model.CreatedDate = DateTime.Now;

            //if (model.Institute_Id > 0)
            
                if (model.Campus_Id > 0)
                {
                    new InstituteCRUD().UpdateCampusRecord(model);
                    return RedirectToAction("Course", new { InstituteId = model.Institute_Id, CampusName = model.CampusName });
                }
                
               
                
                    instituteid = new InstituteCRUD().AddDataCampus(model);
                 

            
            return RedirectToAction("Course", new { CampusId = instituteid, CampusName = model.CampusName, InstituteId=instituteid });


        }


        public static string GetEnumDescription1<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

      
        //Get Course

        public ActionResult Course(int CampusId = 0, string CampusName = "",int InstituteId = 0)
        {

            CourseViewModel model = new CourseViewModel();

            if (InstituteId > 0)
            {
                model = new InstituteCRUD().GetCourse(InstituteId, CampusName);
            }



            ViewBag.Level = new SelectList(Enum.GetValues(typeof(Level)).Cast<Level>().OrderBy(k2 => GetEnumDescription((Level)k2)).ToDictionary(k2 => (int)k2, v => v.ToString()), "Key", "Value");
            return View("Course", model);
        }
        // POST: /Course/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Course(CourseViewModel model)
        
        {
                model.CreatedDate = DateTime.Now;
               var id= new InstituteCRUD().AddDataCourse(model);

            //return RedirectToAction("Batch", "Institute");
            return RedirectToAction("Batch", new { CourseId = id, CourseName = model.Course_Name });
        }


        public static string GetEnumDescription2<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
      

       

        
        public ActionResult Batch(int CourseId = 0, string CourseName = "",int Id=0)
        {

            BatchViewModel model = new BatchViewModel();
            if (Id > 0)
            {
                model = GetBatch(Id);
            }
            //data pass to view from controller//
            model.Course_Id = CourseId;
            model.Course_Name = CourseName;
            model.CreatedDate = DateTime.Now;
            ViewBag.Level = new SelectList(Enum.GetValues(typeof(Level)).Cast<Level>().OrderBy(k2 => GetEnumDescription((Level)k2)).ToDictionary(k2 => (int)k2, v => v.ToString()), "Key", "Value");
            return View("Batch", model);
        }

        // POST: /Batch/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Batch(BatchViewModel model)
        {
                model.CreatedDate = DateTime.Now;
                AddDataBatch(model);

            return RedirectToAction("RegisterComplete", "Institute");
        }


        public BatchViewModel GetBatch(int id = 0)
        {
            var result = new BatchViewModel();
            try
            {

                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();

                        {

                            result = db.Query<BatchViewModel>
                                    ("Select * from Tbl_Batch where Batch_Id=@Id order by Batch_Id  desc", new
                                    {
                                        Id = id
                                    }).FirstOrDefault();
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

        public bool UpdateBatchRecord(BatchViewModel model)
        {
            try
            {
                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();
                        string sql = "Update  [Tbl_Batch] set Batch_Name=@Batch_Name,Status=@Status,Admission_Start=@Admission_Start,Admission_End=@Admission_End,Fee=@Fee,CreatedBy=@CreatedBy  where Institute_Id=@Institute_Id";
                        var update = db.Execute(sql, new
                        {
                            Batch_Name = model.Batch_Name,
                            Status = model.Status,
                            Admission_Start = model.Admission_Start,
                            Admission_End = model.Admission_End,
                            Fee = model.Fee,
                            CreatedBy = model.CreatedBy,
                     
                        });

                        db.Close();

                    }
                    catch (Exception ex)
                    {

                        return false;
                    }
                    finally
                    {
                        db.Close();
                    }
                }

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        public int AddDataBatch(BatchViewModel model)
        {
            var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
            using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
            {
                try
                {
                    db.Open();
                  
                    string sql = "INSERT INTO Tbl_Batch(Course_Id,Batch_Name,Status,Admission_Start,Admission_End,Fee,CreatedBy,CreatedDate) values(@Course_Id,@Batch_Name,@Status,@Admission_Start,@Admission_End,@Fee,@CreatedBy,@CreatedDate)SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    var returnid=db.Query<int>(sql, model).SingleOrDefault();
                    

                    db.Close();                   
                    return returnid;
   
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Error", nameof(Batch), ex);
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public ActionResult RegisterComplete()
        {
            return View();
        }

    }
}
