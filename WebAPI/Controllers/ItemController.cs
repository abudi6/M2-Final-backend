using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemLibrary.Data;
using SystemLibrary.Models;
using System;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ISqlData _db;

        public ItemController(ISqlData db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ListItems()
        {
            List<ItemModel> lists = _db.ListItems();
            return Ok(lists);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public ActionResult AddItem([FromBody] ItemForm form)
        {
            string randomString = GenerateRandomString(10);

            ItemModel item = new ItemModel();
            item.Name = form.Name;
            item.Code = GenerateRandomString(5);
            item.Brand = form.Brand;
            item.UnitPrice = form.UnitPrice;
            item.DateAdded = DateTime.Now;
            _db.AddItem(item);

            return Ok("Item Registered");
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("api/[controller]/delete/{code}")]
        public ActionResult DeleteItem(string code) 
        {
            _db.DeleteItem(code);
            return Ok("Item Deleted");
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/[controller]/update/{code}")]
        public ActionResult UpdateItem(string code, [FromBody] ItemForm form) 
        {
            ItemModel item = new ItemModel();
            item.Name = form.Name;
            item.Code = code;
            item.Brand = form.Brand;
            item.UnitPrice = form.UnitPrice;

            _db.UpdateItem(item);

            return Ok("Item Updated");
        }
    }
}
