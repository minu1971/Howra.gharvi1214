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
    public class InstituteCRUD
    {
        int updateid = 0;
        string name = "";

        //Institute
        public int AddDataInstitute(InstituteViewModels model)
        {

            var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
            using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
            {
                try
                {
                    db.Open();

                    string sql = "INSERT INTO Tbl_Institute(Name,Url,Phone,Email,CreatedBy,CreatedDate) values(@Name,@Url,@Phone,@Email,@CreatedBy,@CreatedDate)SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    var id = db.Query<int>(sql, model).SingleOrDefault();


                    db.Close();

                    return id;

                }
                catch (Exception ex)
                {

                    return 0;
                }
                finally
                {
                    db.Close();
                }

            }
        }
        public InstituteViewModels GetInstitute(int id = 0)
        {
            var result = new InstituteViewModels();
            try
            {
                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();

                        {

                            result = db.Query<InstituteViewModels>
                                    ("Select  * from Tbl_Institute where Institute_Id=@Id order by Institute_Id  desc", new
                                    {
                                        Id = id,
                                       
                                    }).FirstOrDefault();

                           
                        }
                        result.Institute_Id = id;


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
        public bool UpdateInstituteRecord(InstituteViewModels model)
        {
            try
            {
                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();
                        string sql = "Update  [Tbl_Institute] set Name=@Name,Url=@Url,Phone=@Phone,Email=@Email,CreatedBy= @CreatedBy where Institute_Id=@Institute_Id";
                        var update = db.Execute(sql, new
                        {
                            Name = model.Name,
                            Url = model.Url,
                            Phone = model.Phone,
                            Email = model.Email,
                            CreatedBy = model.CreatedBy,
                            Institute_Id = model.Institute_Id

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

        //Campus

        public int AddDataCampus(CampusViewModel model)
        {
            var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
            using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
            {

                try
                {
                    db.Open();
                    string sql = "INSERT INTO Tbl_Campus(Institute_Id,CampusName,Address,CityId,CreatedBy,Url,Phone,Email,CreatedDate) values(@Institute_Id,@CampusName,@Address,@CityId,@CreatedBy,@Url,@Phone,@Email,@CreatedDate)SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    var id = db.Query<int>(sql, model).SingleOrDefault();
                    db.Close();
                    return id;

                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Error",  ex);
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public CampusViewModel GetCampus(int id = 0, string name = "")
        {
            var result = new CampusViewModel();
            try
            {

                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();

                        {

                            result = db.Query<CampusViewModel>
                                    ("Select * from Tbl_Campus where Institute_Id=@Id  order by Campus_Id  desc", new
                                    {
                                        Id = id
                                    }).FirstOrDefault();

                            if (result != null)
                            {
                                result.Name = name;

                            }


                        }
                        if (result == null)
                        {
                            result = new CampusViewModel();
                            result.Institute_Id = id;
                            result.Name = name;

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


        public bool UpdateCampusRecord(CampusViewModel model)
        {
            try
            {
                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();
                        string sql = "Update  [Tbl_Campus] set Campus_Name=@CampusName,Address=@Address,CityId=@CityId,CreatedBy=@CreatedBy,Url=@Url,Phone=@Phone,Email=@Email  where Institute_Id=@Institute_Id";
                        var update = db.Execute(sql, new
                        {
                            Campus_Name = model.CampusName,
                            Address = model.Address,
                            CityId = model.CityId,
                            CreatedBy = model.CreatedBy,
                            Url = model.Url,
                            Phone = model.Phone,
                            Email = model.Email,

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



        //Course

        public int AddDataCourse(CourseViewModel model)
        {
            var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
            using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
            {
                try
                {
                    db.Open();
                    string sql = "INSERT INTO Tbl_Course(Campus_Id,Course_Name,Description,Duration,Eligibility,LevelId,CreatedBy,Status,CreatedDate) values(@Campus_Id,@Course_Name,@Description,@Duration,@Eligibility,@LevelId,@CreatedBy,@Status,@CreatedDate)SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    var returnid = db.Query<int>(sql, model).SingleOrDefault();
                    //}


                    db.Close();
                    return returnid;


                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Error",ex);
                }
                finally
                {
                    db.Close();
                }
            }



        }

        public CourseViewModel GetCourse(int id = 0, string name = "")
        {
            var result = new CourseViewModel();
            try
            {

                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();

                        {

                            result = db.Query<CourseViewModel>
                                    ("Select * from Tbl_Course where Institute_Id=@Id", new
                                    {
                                        Id = id
                                    }).FirstOrDefault();

                            //if (result != null)
                            //{
                            //    result.Course_Name = name;

                            //}
                        }

                        if (result == null)
                        {
                            result = new CourseViewModel();
                            //result.Course_Id = id;
                            //result.Course_Name = name;

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

        public bool UpdateCourseRecord(CourseViewModel model)
        {
            try
            {
                var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
                using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        db.Open();
                        string sql = "Update  [Tbl_Course] set Course_Name=@Course_Name,Description=@Description,Duration=@Duration,Eligibility=@Eligibility,LevelId=@LevelId,CreatedBy=@CreatedBy,Status=@Status  where Institute_Id=@Institute_Id";
                        var update = db.Execute(sql, new
                        {
                            Course_Name = model.Course_Name,
                            Description = model.Description,
                            Duration = model.Duration,
                            Eligibility = model.Eligibility,
                            LevelId = model.LevelId,
                            CreatedBy = model.CreatedBy,
                            Status = model.Status


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

        ////Batch
        //public int AddDataBatch(BatchViewModel model)
        //{
        //    var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
        //    using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
        //    {
        //        try
        //        {
        //            db.Open();

        //            string sql = "INSERT INTO Tbl_Batch(Course_Id,Batch_Name,Status,Admission_Start,Admission_End,Fee,CreatedBy,CreatedDate) values(@Course_Id,@Batch_Name,@Status,@Admission_Start,@Admission_End,@Fee,@CreatedBy,@CreatedDate)SELECT CAST(SCOPE_IDENTITY() AS INT)";
        //            var returnid = db.Query<int>(sql, model).SingleOrDefault();


        //            db.Close();
        //            return returnid;

        //        }
        //        catch (Exception ex)
        //        {

        //            throw new ArgumentException("Error", nameof(Batch), ex);
        //        }
        //        finally
        //        {
        //            db.Close();
        //        }
        //    }
        //}
        //public BatchViewModel GetBatch(int id = 0)
        //{
        //    var result = new BatchViewModel();
        //    try
        //    {

        //        var ConnectionString = "Initial Catalog=Active_Institution_Roaster;Integrated Security=True";
        //        using (System.Data.IDbConnection db = new SqlConnection(ConnectionString))
        //        {
        //            try
        //            {
        //                db.Open();

        //                {

        //                    result = db.Query<BatchViewModel>
        //                            ("Select * from Tbl_Batch where Batch_Id=@Id order by Batch_Id  desc", new
        //                            {
        //                                Id = id
        //                            }).FirstOrDefault();
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

    }
}