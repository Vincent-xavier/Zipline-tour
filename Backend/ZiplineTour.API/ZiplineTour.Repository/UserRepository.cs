﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ZiplineTour.Common;
using ZiplineTour.DBEngine;
using ZiplineTour.Models;

namespace ZiplineTour.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> Users();

        Task<ResultArgs> GetToken(string UserName, string Password);

        Task<int> Register(UserModel userModel);
        Task<List<UserRights>> GetUserRights(int rollbaseId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IServerHandler _serverHandler;
        public UserRepository(IServerHandler serverHandler)
        {
            _serverHandler = serverHandler;
        }

        public async Task<List<UserModel>> Users()
        {
            var listUsers = new List<UserModel>();

            try
            {
                listUsers = (await _serverHandler.QueryAsync<UserModel>(_serverHandler.Connection, StoredProc.User.Users, CommandType.StoredProcedure, null)).ToList();

            }
            catch (Exception ex)
            {

                ErrorLog log = new ErrorLog();
                log.WriteErrorToText(ex);
            }
            return listUsers;
        }

        public async Task<UserModel> GetToken(string Email, string Password)
        {
            var param = new DynamicParameters();
            var user = new UserModel();
            try
            {
                param.Add("@P_email", Email, DbType.String, ParameterDirection.Input);
                param.Add("@P_pass", Password, DbType.String, ParameterDirection.Input);
                user = await _serverHandler.QueryFirstOrDefaultAsync<UserModel>(_serverHandler.Connection, StoredProc.User.UserLogin, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {

                ErrorLog log = new ErrorLog();
                log.WriteErrorToText(ex);
            }
            return user;
        }


        public async Task<int> Register(UserModel userModel)
        {
            var param = new DynamicParameters();
            try
            {
                param.Add("@userName", userModel.Email, DbType.String, ParameterDirection.Input);
                param.Add("@password", userModel.Password, DbType.String, ParameterDirection.Input);
                param.Add("@returnVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _serverHandler.ExecuteAsync(_serverHandler.Connection, "usp_User_Register", CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                ErrorLog log = new ErrorLog();
                log.WriteErrorToText(ex);
            }
            return param.Get<int>("@returnVal");
        }

        public async Task<List<UserRights>> GetUserRights(int rollbaseId)
        {
            var param = new DynamicParameters();
            var result = new List<UserRights>();
            try
            {
                param.Add("@P_RollId", rollbaseId, DbType.Int16, ParameterDirection.Input);
                result = (await _serverHandler.QueryAsync<UserRights>(_serverHandler.Connection, StoredProc.User.UserRights, CommandType.StoredProcedure, param)).ToList(); ;

            }
            catch (Exception ex)
            {
                ErrorLog log = new ErrorLog();
                log.WriteErrorToText(ex);
            }
            return result;
        }
    }
}
