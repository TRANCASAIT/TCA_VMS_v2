using static TCA_VMS.Models.Base;
using static TCA_VMS.Models.Company;
using static TCA_VMS.Models.User;
using static TCA_VMS.Models.VisitorsReport;
using static TCA_VMS.Models.VisitorType;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TCA_VMS.Models.DAO
{
    public class TCA_VMS_DAO
    {
        //FUNCTIONS CREATION

        #region Department

        public static Result StoreDepartment(Department _department)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Department_Name", _department.Department_Name)
                      .AddParam("@User_Logged", _department.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[DepartmentProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<Department> GetDepartments()
        {
            var spOption = 3;
            List<Department> lstDepartments = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[DepartmentProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstDepartments = new List<Department>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstDepartments.Add(new Department()
                            {
                                Department_Id = Convert.ToInt32(item["Department_Id"]),
                                Department_Name = item["Department_Name"].ToString(),
                                Department_Creation_Date = Convert.ToDateTime(item["Department_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstDepartments;
        }

        public static List<Department> GetDepartmentsForms()
        {
            var spOption = 6;
            List<Department> lstDepartments = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[DepartmentProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstDepartments = new List<Department>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstDepartments.Add(new Department()
                            {
                                Department_Id = Convert.ToInt32(item["Department_Id"]),
                                Department_Name = item["Department_Name"].ToString(),
                                Department_Creation_Date = Convert.ToDateTime(item["Department_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstDepartments;
        }

        public static Department GetDepartment(int id)
        {
            var spOption = 2;
            Department _department = new Department();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@Base_Id", id).AddParam("@SpOption", spOption)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[DepartmentProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _department.Department_Id = Convert.ToInt32(dtHeader.Rows[0]["Department_Id"]);
                    _department.Department_Name = dtHeader.Rows[0]["Department_Name"].ToString();
                    _department.Department_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["Department_Creation_Date"]);
                }
            }
            return _department;
        }

        public static Result UpdateDepartment(DepartmentUpdate _department)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Department_Id", _department.Department_Id)
                      .AddParam("@Department_Name", _department.Department_Name)
                      .AddParam("@User_Logged", _department.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[DepartmentProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region Base
        public static Result StoreBase(Base _base)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Base_Name", _base.Base_Name)
                      .AddParam("@Base_Location", _base.Base_Location)
                      .AddParam("@User_Logged", _base.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<Base> GetBases()
        {
            var spOption = 3;
            List<Base> lstBases = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstBases = new List<Base>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstBases.Add(new Base()
                            {
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Base_Name = item["Base_Name"].ToString(),
                                Base_Location = item["Base_Location"].ToString(),
                                Base_Status = Convert.ToBoolean(item["Base_Status"]),
                                Base_Creation_Date = Convert.ToDateTime(item["Base_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstBases;
        }

        public static List<Base> GetBasesForms()
        {
            var spOption = 6;
            List<Base> lstBases = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstBases = new List<Base>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstBases.Add(new Base()
                            {
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Base_Name = item["Base_Name"].ToString(),
                                Base_Location = item["Base_Location"].ToString(),
                                Base_Status = Convert.ToBoolean(item["Base_Status"]),
                                Base_Creation_Date = Convert.ToDateTime(item["Base_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstBases;
        }

        public static Base GetBase(int id)
        {
            var spOption = 2;
            Base _base = new Base();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@Base_Id", id).AddParam("@SpOption", spOption)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _base.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _base.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _base.Base_Location = dtHeader.Rows[0]["Base_Location"].ToString();
                    _base.Base_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["Base_Creation_Date"]);
                    _base.Base_Status = Convert.ToBoolean(dtHeader.Rows[0]["Base_Status"]);
                }
            }
            return _base;
        }

        public static Result UpdateBase(BaseEdit _base)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Base_Id", _base.Base_Id)
                      .AddParam("@Base_Name", _base.Base_Name)
                      .AddParam("@Base_Location", _base.Base_Location)
                      .AddParam("@User_Logged", _base.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static Result UpdateBaseStatus(BaseStatus _base)
        {
            Result result = new Result();
            var spOption = 5;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Base_Id", _base.Base_Id)
                      .AddParam("@Base_Status", _base.Base_Status)
                      .AddParam("@User_Logged", _base.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region UserType

        public static Result StoreUserType(UserType _userType)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@UserType_Name", _userType.UserType_Name)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<UserType> GetUserTypes(string userTypeName)
        {
            List<UserType> lstUserTypes = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .AddParam("@userTypeName", userTypeName)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstUserTypes = new List<UserType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstUserTypes.Add(new UserType()
                            {
                                UserType_Id = Convert.ToInt32(item["UserType_Id"]),
                                UserType_Name = item["UserType_Name"].ToString(),
                                UserType_Creation_Date = Convert.ToDateTime(item["UserType_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstUserTypes;
        }

        public static UserType GetUserType(int id)
        {
            UserType _userType = new UserType();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@SpOption", spOption)
                                   .AddParam("@UserType_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _userType.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]);
                    _userType.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _userType.UserType_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["UserType_Creation_Date"]);
                }
            }
            return _userType;
        }

        public static Result UpdateUserType(UserType _userType)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@UserType_Id", _userType.UserType_Id)
                      .AddParam("@UserType_Name", _userType.UserType_Name)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion


        #region User

        public static Result StoreUser(UserPost _user)
        {
            _user.User_Password = GetSHA256(_user.User_Password);
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@Base_Id", _user.Base_Id)
                      .AddParam("@UserType_Id", _user.UserType_Id)
                      .AddParam("@User_Name", _user.User_Name)
                      .AddParam("@UserName", _user.UserName)
                      .AddParam("@User_Email", _user.User_Email)
                      .AddParam("@User_Last_Name", _user.User_Last_Name)
                      .AddParam("@User_Password", _user.User_Password)
                      .AddParam("@User_Logged", _user.User_Logged)
                      .AddParam("@UserNumber", _user.User_Number)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static Result StoreUserSA(User _user)
        {
            _user.User_Password = GetSHA256(_user.User_Password);
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@Base_Id", _user.Base_Id)
                      .AddParam("@UserType_Id", _user.UserType_Id)
                      .AddParam("@User_Name", _user.User_Name)
                      .AddParam("@UserName", _user.UserName)
                      .AddParam("@UserNumber", _user.User_Number)
                      .AddParam("@User_Last_Name", _user.User_Last_Name)
                      .AddParam("@User_Email", _user.User_Email)
                      .AddParam("@User_Password", _user.User_Password)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static List<User> GetUsers()
        {
            List<User> lstUsers = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        //.AddParam("@userTypeName",userTypeName)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstUsers = new List<User>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstUsers.Add(new User()
                            {
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                UserType_Id = Convert.ToInt32(item["UserType_Id"]),
                                User_Name = item["User_Name"].ToString(),
                                User_Email = item["User_Email"].ToString(),
                                User_Number = item["User_Number"].ToString(),
                                User_Last_Name = item["User_Last_Name"].ToString(),
                                UserName = item["UserName"].ToString(),
                                User_Status = Convert.ToBoolean(item["User_Status"]),
                                Base_Name = item["Base_Name"].ToString(),
                                UserType_Name = item["UserType_Name"].ToString(),
                                User_Creation_Date = Convert.ToDateTime(item["User_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstUsers;
        }

        public static User GetUser(int id)
        {
            User _user = new User();
            var spOption = 4;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption", spOption)
                                   .AddParam("@User_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _user.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _user.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _user.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]);
                    _user.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _user.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _user.User_Name = dtHeader.Rows[0]["User_Name"].ToString();
                    _user.UserName = dtHeader.Rows[0]["UserName"].ToString();
                    _user.User_Status = Convert.ToBoolean(dtHeader.Rows[0]["User_Status"]);
                    _user.User_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["User_Creation_Date"]);
                }
            }
            return _user;
        }

        public static Result UpdateUser(UserPut _user)
        {
            Result result = new Result();
            var spOption = 5;
            _user.User_Password = GetSHA256(_user.User_Password);
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@User_Id", _user.User_Id)
                      .AddParam("@Base_Id", _user.Base_Id)
                      .AddParam("@UserType_Id", _user.UserType_Id)
                      .AddParam("@User_Name", _user.User_Name)
                      .AddParam("@User_Last_Name", _user.User_Last_Name)
                      .AddParam("@UserName", _user.UserName)
                      .AddParam("@User_Email", _user.User_Email)
                      .AddParam("@User_Password", _user.User_Password)
                      .AddParam("@User_Logged", _user.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static User GetUserLogin(string userName, string password)
        {
            User _user = new User();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@UserName", userName)
                                   .AddParam("@Password", password)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[Login]");

                if (dtHeader.Rows.Count > 0)
                {
                    _user.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _user.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _user.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]);
                    _user.UserName = dtHeader.Rows[0]["User_Name"].ToString();
                    _user.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _user.User_Status = Convert.ToBoolean(dtHeader.Rows[0]["User_Status"]);
                }
            }
            return _user;
        }

        public static Result UpdateUserStatus(UserStatus _user)
        {
            Result result = new Result();
            var spOption = 6;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@User_Id", _user.User_Id)
                      .AddParam("@User_Status", _user.User_Status)
                      .AddParam("@User_Logged", _user.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }


        #endregion

        #region Company

        public static Result StoreCompany(CompanyPost _company)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@Company_Name", _company.Company_Name)
                      .AddParam("@Company_Address", _company.Company_Address)
                      .AddParam("@Company_Phone_Number", _company.Company_Phone_Number)
                      .AddParam("@Base_Id", _company.Base_Id)
                      .AddParam("@User_Logged", _company.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {

                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static List<Company> GetCompanies(int userId)
        {
            List<Company> lstCompanies = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl
                        .AddParam("@SpOption", spOption)
                        .AddParam("@userParam", userId)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstCompanies = new List<Company>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstCompanies.Add(new Company()
                            {
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                Company_Address = item["Company_Address"].ToString(),
                                Company_Phone_Number = item["Company_Phone_Number"].ToString(),
                                Company_Status = Convert.ToBoolean(item["Company_Status"]),
                                Company_Creation_Date = Convert.ToDateTime(item["Company_Creation_Date"]),
                                Base_Name = item["Base_Name"].ToString(),
                                Base_Id = Convert.ToInt32(item["Base_Id"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstCompanies;
        }

        public static List<Company> GetCompaniesForms(int userId)
        {
            List<Company> lstCompanies = null;
            var spOption = 6;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl
                        .AddParam("@SpOption", spOption)
                        .AddParam("@userParam", userId)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstCompanies = new List<Company>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstCompanies.Add(new Company()
                            {
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                Company_Address = item["Company_Address"].ToString(),
                                Company_Phone_Number = item["Company_Phone_Number"].ToString(),
                                Company_Status = Convert.ToBoolean(item["Company_Status"]),
                                Company_Creation_Date = Convert.ToDateTime(item["Company_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstCompanies;
        }

        public static Company GetCompany(int id)
        {
            Company _company = new Company();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption", spOption)
                                   .AddParam("@Company_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _company.Company_Id = Convert.ToInt32(dtHeader.Rows[0]["Company_Id"]);
                    _company.Company_Name = dtHeader.Rows[0]["Company_Name"].ToString();
                    _company.Company_Address = dtHeader.Rows[0]["Company_Address"].ToString();
                    _company.Company_Phone_Number = dtHeader.Rows[0]["Company_Phone_Number"].ToString();
                    _company.Company_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["Company_Creation_Date"]);
                    _company.Company_Status = Convert.ToBoolean(dtHeader.Rows[0]["Company_Status"]);
                }
            }
            return _company;
        }

        public static Result UpdateCompany(CompanyPost _company)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@Company_Id", _company.Company_Id)
                      .AddParam("@Base_Id", _company.Base_Id)
                      .AddParam("@Company_Name", _company.Company_Name)
                      .AddParam("@Company_Address", _company.Company_Address)
                      .AddParam("@Company_Phone_Number", _company.Company_Phone_Number)
                      .AddParam("@User_Logged", _company.User_Logged)
                      .AddParam("@Company_Status", _company.Company_Status)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static Result UpdateCompanyStatus(CompanyStatus _company)
        {
            Result result = new Result();
            var spOption = 5;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Company_Id", _company.Company_Id)
                      .AddParam("@Company_Status", _company.Company_Status)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@User_Logged", _company.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region IDType
        public static Result StoreIDType(IDType _idType)
        {
            Result result = new Result();
            var SpOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl
                      .AddParam("@SpOption", SpOption)
                      .AddParam("@IDType_Name", _idType.IDType_Name)
                      .AddParam("@User_Logged", _idType.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<IDType> GetIDTypes()
        {
            List<IDType> lstIDTypes = null;
            var SpOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl
                        .AddParam("@SpOption", SpOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstIDTypes = new List<IDType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstIDTypes.Add(new IDType()
                            {
                                IDType_Id = Convert.ToInt32(item["IDType_Id"]),
                                IDType_Name = item["IDType_Name"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstIDTypes;
        }

        public static IDType GetIDType(int id)
        {
            IDType _IDType = new IDType();
            var SpOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption", SpOption)
                                   .AddParam("@IDType_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _IDType.IDType_Id = Convert.ToInt32(dtHeader.Rows[0]["IDType_Id"]);
                    _IDType.IDType_Name = dtHeader.Rows[0]["IDType_Name"].ToString();
                }
            }
            return _IDType;
        }

        public static Result UpdateIDType(IDType _IDType)
        {
            Result result = new Result();
            var SpOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", SpOption)
                      .AddParam("@IDType_Id", _IDType.IDType_Id)
                      .AddParam("@IDType_Name", _IDType.IDType_Name)
                      .AddParam("@User_Logged", _IDType.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region VisitorType

        public static Result StoreVisitorType(VisitorTypePrqst _visitorType)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@VisitorType_Name", _visitorType.VisitorType_Name)
                      .AddParam("@VisitorType_Bagde_Color", _visitorType.VisitorType_Bagde_Color)
                      .AddParam("@VisitorType_Badge_Number", _visitorType.VisitorType_Bagde_Number)
                      .AddParam("@User_Logged", _visitorType.User_Logged)
                      .AddParam("@Base_Id", _visitorType.Base_Id)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<VisitorType> GetVisitorTypes()
        {
            List<VisitorType> lstVisitorTypes = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorTypes = new List<VisitorType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorTypes.Add(new VisitorType()
                            {
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                VisitorType_Bagde_Number = item["VisitorType_Badge_Number"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorType_Bagde_Color = item["VisitorType_Badge_Color"].ToString(),
                                VisitorType_Badge_Available = Convert.ToInt32(item["VisitorType_Badge_Available"]),
                                VisitorType_Badge_InUse = Convert.ToInt32(item["VisitorType_Badge_InUse"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorTypes;
        }

        public static List<VisitorType> GetVisitorTypesForms(int userId)
        {
            List<VisitorType> lstVisitorTypes = null;
            var spOption = 5;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .AddParam("@userParam", userId)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorTypes = new List<VisitorType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorTypes.Add(new VisitorType()
                            {
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                VisitorType_Bagde_Number = item["VisitorType_Badge_Number"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorType_Bagde_Color = item["VisitorType_Badge_Color"].ToString(),
                                VisitorType_Badge_Available = Convert.ToInt32(item["VisitorType_Badge_Available"]),
                                VisitorType_Badge_InUse = Convert.ToInt32(item["VisitorType_Badge_InUse"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorTypes;
        }

        public static VisitorType GetVisitorType(int id)
        {
            VisitorType _visitorType = new VisitorType();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@SpOption", spOption)
                                   .AddParam("@VisitorType_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _visitorType.VisitorType_Id = Convert.ToInt32(dtHeader.Rows[0]["VisitorType_Id"]);
                    _visitorType.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _visitorType.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _visitorType.VisitorType_Name = dtHeader.Rows[0]["VisitorType_Name"].ToString();
                    _visitorType.VisitorType_Bagde_Number = dtHeader.Rows[0]["VisitorType_Badge_Number"].ToString();
                    _visitorType.VisitorType_Bagde_Color = dtHeader.Rows[0]["VisitorType_Badge_Color"].ToString();
                }
            }
            return _visitorType;
        }

        public static Result UpdateVisitorType(VisitorTypeUpd _visitorType)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {
                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@VisitorType_Id", _visitorType.VisitorType_Id)
                      .AddParam("@Base_Id", _visitorType.Base_Id)
                      .AddParam("@VisitorType_Name", _visitorType.VisitorType_Name)
                      .AddParam("@VisitorType_Badge_Number", _visitorType.VisitorType_Bagde_Number)
                      .AddParam("@VisitorType_Bagde_Color", _visitorType.VisitorType_Bagde_Color)
                      .AddParam("@User_Logged", _visitorType.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }


        #endregion

        #region VisitorsReport
        public static Result StoreVisitorsReport(VisitorsReportPost _visitorsReport)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@VisitorsReport_Name", _visitorsReport.VisitorsReport_Name)//
                      .AddParam("@VisitorsReport_LastName", _visitorsReport.VisitorsReport_LastName)//
                      .AddParam("@VisitorsReport_Subject", _visitorsReport.VisitorsReport_Subject)//
                      .AddParam("@VisitorsReport_RecievedBy", _visitorsReport.VisitorsReport_RecievedBy)//
                      .AddParam("@VisitorsReport_Photo", _visitorsReport.VisitorsReport_Photo)//
                      .AddParam("@VisitorsReport_Laptop", _visitorsReport.VisitorsReport_Laptop)//
                      .AddParam("@VisitorsReport_Laptop_Brand", _visitorsReport.VisitorsReport_Laptop_Brand)
                      .AddParam("@VisitorsReport_Laptop_Serial_Number", _visitorsReport.VisitorsReport_Laptop_Serial_Number)
                      .AddParam("@User_Logged", _visitorsReport.User_Logged)
                      .AddParam("@Company_Id", _visitorsReport.Company_Id)//
                      .AddParam("@IDType_Id", _visitorsReport.IDType_Id)//
                      .AddParam("@VisitorType_Id", _visitorsReport.VisitorType_Id)//
                      .AddParam("@User_Id", _visitorsReport.User_Id)//
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }


        public static List<VisitorsReport> GetVisitorsReports(int userId)
        {
            List<VisitorsReport> lstVisitorsReport = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .AddParam("@userParam", userId)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorsReport = new List<VisitorsReport>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorsReport.Add(new VisitorsReport()
                            {
                                VisitorsReport_Id = Convert.ToInt32(item["VisitorsReport_Id"]),
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                IDType_Id = Convert.ToInt32(item["IDType_Id"]),
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                IDType_Name = item["IDType_Name"].ToString(),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                User_UserName = item["User_Name"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorsReport_Badge_Number = item["VisitorsReport_Badge_Number"].ToString(),
                                VisitorsReport_FullName = item["VisitorsReport_FullName"].ToString(),
                                VisitorsReport_Name = item["VisitorsReport_Name"].ToString(),
                                VisitorsReport_LastName = item["VisitorsReport_LastName"].ToString(),
                                VisitorsReport_RecievedBy = Convert.ToInt32(item["VisitorsReport_RecievedBy"]),
                                VisitorsReport_Subject = item["VisitorsReport_Subject"].ToString(),
                                VisitorsReport_Photo = item["VisitorsReport_Photo"].ToString(),
                                VisitorsReport_Laptop_Status = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                VisitorsReport_Laptop = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                LaptopRegistered = item["LaptopRegistered"].ToString(),
                                VisitorsReport_StartHour = item["VisitorsReport_StartHour"].ToString(),
                                VisitorsReport_Status = Convert.ToBoolean(item["VisitorsReport_Status"]),
                                VisitorsReport_Laptop_Serial_Number = item["VisitorsReport_Laptop_Serial_Number"].ToString(),
                                VisitorsReport_Laptop_Brand = item["VisitorsReport_Laptop_Brand"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorsReport;
        }


        public static List<VisitorsReport> GetVisitorsReportsHistory()
        {
            List<VisitorsReport> lstVisitorsReport = null;
            var spOption = 5;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorsReport = new List<VisitorsReport>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorsReport.Add(new VisitorsReport()
                            {
                                VisitorsReport_Id = Convert.ToInt32(item["VisitorsReport_Id"]),
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                IDType_Id = Convert.ToInt32(item["IDType_Id"]),
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                IDType_Name = item["IDType_Name"].ToString(),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                User_UserName = item["User_Name"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorsReport_Badge_Number = item["VisitorsReport_Badge_Number"].ToString(),
                                VisitorsReport_FullName = item["VisitorsReport_FullName"].ToString(),
                                VisitorsReport_Name = item["VisitorsReport_Name"].ToString(),
                                VisitorsReport_LastName = item["VisitorsReport_LastName"].ToString(),
                                VisitorsReport_RecievedBy = Convert.ToInt32(item["VisitorsReport_RecievedBy"]),
                                VisitorsReport_Subject = item["VisitorsReport_Subject"].ToString(),
                                VisitorsReport_Photo = item["VisitorsReport_Photo"].ToString(),
                                VisitorsReport_Laptop_Status = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                VisitorsReport_Laptop = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                LaptopRegistered = item["LaptopRegistered"].ToString(),
                                VisitorsReport_StartHour = item["VisitorsReport_StartHour"].ToString(),
                                VisitorsReport_OutHour = item["VisitorsReport_OutHour"].ToString(),
                                VisitorsReport_Status = Convert.ToBoolean(item["VisitorsReport_Status"]),
                                VisitorsReport_Laptop_Serial_Number = item["VisitorsReport_Laptop_Serial_Number"].ToString(),
                                VisitorsReport_Laptop_Brand = item["VisitorsReport_Laptop_Brand"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorsReport;
        }


        public static List<VisitorsReport> GetVisitorsReportsHistoryFiltered(string startDate, string endDate)
        {
            List<VisitorsReport> lstVisitorsReport = null;
            var spOption = 6;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .AddParam("@StartDate", DateTime.Parse(startDate))
                        .AddParam("@EndDate", DateTime.Parse(endDate))
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorsReport = new List<VisitorsReport>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorsReport.Add(new VisitorsReport()
                            {
                                VisitorsReport_Id = Convert.ToInt32(item["VisitorsReport_Id"]),
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                IDType_Id = Convert.ToInt32(item["IDType_Id"]),
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                IDType_Name = item["IDType_Name"].ToString(),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                User_UserName = item["User_Name"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorsReport_Badge_Number = item["VisitorsReport_Badge_Number"].ToString(),
                                VisitorsReport_FullName = item["VisitorsReport_FullName"].ToString(),
                                VisitorsReport_Name = item["VisitorsReport_Name"].ToString(),
                                VisitorsReport_LastName = item["VisitorsReport_LastName"].ToString(),
                                VisitorsReport_RecievedBy = Convert.ToInt32(item["VisitorsReport_RecievedBy"]),
                                VisitorsReport_Subject = item["VisitorsReport_Subject"].ToString(),
                                VisitorsReport_Photo = item["VisitorsReport_Photo"].ToString(),
                                VisitorsReport_Laptop_Status = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                VisitorsReport_Laptop = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                LaptopRegistered = item["LaptopRegistered"].ToString(),
                                VisitorsReport_StartHour = item["VisitorsReport_StartHour"].ToString(),
                                VisitorsReport_OutHour = item["VisitorsReport_OutHour"].ToString(),
                                VisitorsReport_Status = Convert.ToBoolean(item["VisitorsReport_Status"]),
                                VisitorsReport_Laptop_Serial_Number = item["VisitorsReport_Laptop_Serial_Number"].ToString(),
                                VisitorsReport_Laptop_Brand = item["VisitorsReport_Laptop_Brand"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorsReport;
        }

        public static VisitorsReport GetVisitorsReport(int id)
        {
            VisitorsReport _visitorsReport = new VisitorsReport();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("SpOption", spOption)
                                   .AddParam("@VisitorsReport_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _visitorsReport.VisitorsReport_Id = Convert.ToInt32(dtHeader.Rows[0]["VisitorsReport_Id"]);
                    _visitorsReport.Company_Id = Convert.ToInt32(dtHeader.Rows[0]["Company_Id"]);
                    _visitorsReport.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _visitorsReport.IDType_Id = Convert.ToInt32(dtHeader.Rows[0]["IDType_Id"]);
                    _visitorsReport.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _visitorsReport.VisitorType_Id = Convert.ToInt32(dtHeader.Rows[0]["VisitorType_Id"]);
                    _visitorsReport.Company_Name = dtHeader.Rows[0]["Company_Name"].ToString();
                    _visitorsReport.IDType_Name = dtHeader.Rows[0]["IDType_Name"].ToString();
                    _visitorsReport.VisitorType_Name = dtHeader.Rows[0]["VisitorType_Name"].ToString();
                    _visitorsReport.User_UserName = dtHeader.Rows[0]["User_Name"].ToString();
                    _visitorsReport.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _visitorsReport.VisitorsReport_Name = dtHeader.Rows[0]["VisitorsReport_FullName"].ToString();
                    _visitorsReport.VisitorsReport_RecievedBy = Convert.ToInt32(dtHeader.Rows[0]["VisitorsReport_RecievedBy"]);
                    _visitorsReport.VisitorsReport_Subject = dtHeader.Rows[0]["VisitorsReport_Subject"].ToString();
                    _visitorsReport.VisitorsReport_Photo = dtHeader.Rows[0]["VisitorsReport_Photo"].ToString();
                    _visitorsReport.VisitorsReport_Laptop_Status = Convert.ToBoolean(dtHeader.Rows[0]["VisitorsReport_Laptop"]);
                    _visitorsReport.LaptopRegistered = dtHeader.Rows[0]["LaptopRegistered"].ToString();
                    _visitorsReport.VisitorsReport_Status = Convert.ToBoolean(dtHeader.Rows[0]["VisitorsReport_Status"]);
                    _visitorsReport.VisitorsReport_StartHour = dtHeader.Rows[0]["VisitorsReport_StartHour"].ToString();
                    _visitorsReport.VisitorsReport_Badge_Number = dtHeader.Rows[0]["VisitorsReport_Badge_Number"].ToString();
                }
            }
            return _visitorsReport;
        }


        public static Result UpdateVisitorsReport_Status(VisitorsReportStatus visitorsReportStatus)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@VisitorsReport_Id", visitorsReportStatus.VisitorsReport_Id)
                      .AddParam("@User_Logged", visitorsReportStatus.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }


        #endregion

        #region Staff
        public static Result StoreStaff(StaffPost staff)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Staff_Name", staff.Staff_Name)
                      .AddParam("@Staff_LastName", staff.Staff_LastName)
                      .AddParam("@Staff_Number", staff.Staff_Number)
                      .AddParam("@Staff_PhoneNumber", staff.Staff_PhoneNumber)
                      .AddParam("@Staff_Email", staff.Staff_Email)
                      .AddParam("@Base_Id", staff.Base_Id)
                      .AddParam("@Department_Id", staff.Department_Id)
                      .AddParam("@User_Logged", staff.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[StaffProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<Staff> GetStaff()
        {
            var spOption = 3;
            List<Staff> lstStaff = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[StaffProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstStaff = new List<Staff>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstStaff.Add(new Staff()
                            {
                                Staff_Id = Convert.ToInt32(item["Staff_Id"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Department_Id = Convert.ToInt32(item["Department_Id"]),
                                Staff_Name = item["Staff_Name"].ToString(),
                                Staff_LastName = item["Staff_LastName"].ToString(),
                                Staff_Number = item["Staff_Number"].ToString(),
                                Staff_PhoneNumber = item["Staff_PhoneNumber"].ToString(),
                                Staff_Email = item["Staff_Email"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                Department_Name = item["Department_Name"].ToString(),
                                Staff_Status = Convert.ToBoolean(item["Staff_Status"]),
                                Staff_Creation_Date = item["Staff_Creation_Date"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstStaff;
        }

        public static List<Staff> GetStaffForms(int userId)
        {
            var spOption = 6;
            List<Staff> lstStaff = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                                                .AddParam("@userParam", userId)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[StaffProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstStaff = new List<Staff>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstStaff.Add(new Staff()
                            {
                                Staff_Id = Convert.ToInt32(item["Staff_Id"]),
                                Staff_Name = item["Staff_Name"].ToString(),
                                Staff_LastName = item["Staff_LastName"].ToString(),
                                Staff_Number = item["Staff_Number"].ToString(),
                                Staff_PhoneNumber = item["Staff_PhoneNumber"].ToString(),
                                Staff_Email = item["Staff_Email"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                Department_Name = item["Department_Name"].ToString(),
                                Staff_Status = Convert.ToBoolean(item["Staff_Status"]),
                                Staff_Creation_Date = item["Staff_Creation_Date"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstStaff;
        }

        //public static Staff GetStaff(int id)
        //{
        //    var spOption = 2;
        //    Base _base = new Base();
        //    using (var bl = new Business())
        //    {
        //        DataTable dtHeader = bl.AddParam("@Base_Id", id).AddParam("@SpOption", spOption)
        //                           .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

        //        if (dtHeader.Rows.Count > 0)
        //        {
        //            _base.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
        //            _base.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
        //            _base.Base_Location = dtHeader.Rows[0]["Base_Location"].ToString();
        //            _base.Base_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["Base_Creation_Date"]);
        //            _base.Base_Status = Convert.ToBoolean(dtHeader.Rows[0]["Base_Status"]);
        //        }
        //    }
        //    return _base;
        //}

        public static Result UpdateStaff(StaffPut _staff)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Staff_Id", _staff.Staff_Id)
                      .AddParam("@Staff_Name", _staff.Staff_Name)
                      .AddParam("@Staff_LastName", _staff.Staff_LastName)
                      .AddParam("@Staff_Number", _staff.Staff_Number)
                      .AddParam("@Staff_PhoneNumber", _staff.Staff_PhoneNumber)
                      .AddParam("@Staff_Email", _staff.Staff_Email)
                      .AddParam("@Base_Id", _staff.Base_Id)
                      .AddParam("@Department_Id", _staff.Department_Id)
                      .AddParam("@User_Logged", _staff.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[StaffProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static Result UpdateStaffStatus(StaffStatus _staff)
        {
            Result result = new Result();
            var spOption = 5;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Staff_Id", _staff.Staff_Id)
                      .AddParam("@Staff_Status", _staff.Staff_Status)
                      .AddParam("@User_Logged", _staff.User_Logged)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[StaffProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region Methods
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


        #endregion
    }
}
