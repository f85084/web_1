﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class UserWeb
    {
        public IEnumerable<User> Users
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;
                List<User> users = new List<User>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetUsers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(rdr["Id"]);
                        user.UserAccount = rdr["UserAccount"].ToString();
                        //user.UserClass = Convert.ToInt32(rdr["UserClass"]);
                        user.UserClass = rdr["UserClass"].ToString();
                        user.Email = rdr["Email"].ToString();
                        user.Password = rdr["Password"].ToString();
                        user.UserName = rdr["UserName"].ToString();
                        user.CreatDate = Convert.ToDateTime(rdr["CreatDate"]);
                        user.MofiyDate = Convert.ToDateTime(rdr["MofiyDate"]);
                        users.Add(user);
                    }
                }
                return users;
            }
        }

        public void AddGamer(User user)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["webContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddGamer", con)
                //把Gamer透過spAddGamer加進DataBase裡面
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamUserAccount = new SqlParameter
                {
                    ParameterName = "@UserAccount",
                    Value = user.UserAccount
                };
                cmd.Parameters.Add(sqlParamUserAccount);

                SqlParameter sqlParamUserClass = new SqlParameter
                {
                    ParameterName = "@UserClass",
                    Value = user.UserClass
                };
                cmd.Parameters.Add(sqlParamUserClass);

                SqlParameter sqlParamEmail = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email
                };
                cmd.Parameters.Add(sqlParamEmail);

                SqlParameter sqlParamPassword = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                cmd.Parameters.Add(sqlParamPassword);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = user.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = user.CreatDate
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                SqlParameter sqlParamMofiyDate = new SqlParameter
                {
                    ParameterName = "@MofiyDate",
                    Value = user.MofiyDate
                };
                cmd.Parameters.Add(sqlParamMofiyDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}