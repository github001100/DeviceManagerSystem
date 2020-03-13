using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CAYA.API.Models
{
    public class UsersRepository : IUsersRepository
    {
        //查询
        //public async Task<Users> GetUser(string id)
        //{
        //    using (Db.UseDatabase("default"))//确定数据库名称   （此处名称为apollo设置，根据需要自行修改）
        //    {
        //        var x = Db.T($"select * from Users where UserID={id}").ExecuteEntityAsync<Users>();
        //        return await x;
        //    }
        //}
        //删除
        //public async Task<int> DeleteUser(string ID)
        //{
        //    using (Db.UseDatabase("default"))
        //    {
        //        return await Db.T($"delete from Users where UserID={ID}").ExecuteNonQueryAsync();
        //    }
        //}
        //添加
        //public async Task<int> AddAUsers(Users UsersItem)
        //{
        //    using (Db.UseDatabase("default"))
        //    {
        //        return await Db.T($"insert into Users(UserID,Pwd,UserName,CreatedOn) values({UsersItem.UserID},{UsersItem.Pwd},{UsersItem.UserName},{UsersItem.CreatedOn})").ExecuteNonQueryAsync();
        //    }
        //}
        //修改
        //public async Task<int> UpdateUsers(Users UserItem)
        //{
        //    using (Db.UseDatabase("default"))
        //    {
        //        return await Db.T($"update Users set Pwd={UserItem.Pwd},UserName={UserItem.UserName},CreatedOn={UserItem.CreatedOn} where UserID={UserItem.UserID}").ExecuteNonQueryAsync();
        //    }
        //}
    }
}
