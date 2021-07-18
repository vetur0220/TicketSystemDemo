using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystemDemo.Models;
using TicketSystemDemo.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Z.EntityFramework.Plus;
namespace TicketSystemDemo.Controllers
{

    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly TicketSystemContext _context;
        public ApiController(TicketSystemContext ticketSystemContext)
        {
            _context = ticketSystemContext;
        }
        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> getUser()
        {
            var data = await _context.User.ToListAsync();
            var temp = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return Content(temp, "application/json");
        }
        /// <summary>
        /// 取得使用者類型
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> getUserType()
        {
            var data = await _context.UserType.ToListAsync();
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data), "application/json");
        }
        /// <summary>
        /// 取得TicketType
        /// </summary>
        /// <param name="UserTypeKey">使用者類型</param>
        /// <returns></returns>
        public async Task<IActionResult> getTicketType(Guid? UserTypeKey)
        {
            List<TicketType> data = new List<TicketType>();


            if (UserTypeKey == Guid.Parse("0b87b103-c317-4be1-bc77-bfbda650f44a"))
            {
                data = await _context.TicketType.ToListAsync();
            }
            else
            {
                data = await _context.TicketType.Where(e => e.UserTypeKey == UserTypeKey || e.UserTypeKey == Guid.Empty).ToListAsync();
            }
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data), "application/json");
        }
        /// <summary>
        /// 取得 Priority
        /// </summary>
        /// <returns></returns>
        public IActionResult getPriority()
        {
            List<TicketSystemDemo.Models.ViewModels.ViewValue> data = new List<TicketSystemDemo.Models.ViewModels.ViewValue>()
            {
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="1",Value="1"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="2",Value="2"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="3",Value="3"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="4",Value="4"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="5",Value="5"},
            };
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data), "application/json");
        }
        public IActionResult getSeverity()
        {
            List<TicketSystemDemo.Models.ViewModels.ViewValue> data = new List<TicketSystemDemo.Models.ViewModels.ViewValue>()
            {
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="1",Value="1"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="2",Value="2"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="3",Value="3"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="4",Value="4"},
                new TicketSystemDemo.Models.ViewModels.ViewValue(){Name="5",Value="5"},
            };
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data), "application/json");
        }
        /// <summary>
        /// 儲存Ticket
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> saveTicket(Ticket Data)
        {
            var Resources = new Resources();
            try
            {
                if (Data.TicketKey == Guid.Empty)
                {
                    _context.Ticket.Add(new Ticket
                    {
                        TicketKey = Guid.NewGuid(),
                        TicketName = Data.TicketName,
                        Description = Data.Description,
                        IsResolve = Data.IsResolve,
                        Severity = Data.Severity,
                        Summary = Data.Summary,
                        Priority = Data.Priority,
                        TicketTypeKey = Data.TicketTypeKey,
                    });
                    await _context.SaveChangesAsync();
                    Resources.result = true;
                    Resources.msg = "Success";
                    return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
                }
                else
                {
                    _context.Ticket.Where(e => e.TicketKey == Data.TicketKey).Update(c => new Models.Ticket
                    {
                        TicketName = Data.TicketName,
                        Description = Data.Description,
                        IsResolve = Data.IsResolve,
                        Severity = Data.Severity,
                        Summary = Data.Summary,
                        Priority = Data.Priority,
                        TicketTypeKey = Data.TicketTypeKey,

                    });
                    await _context.SaveChangesAsync();
                    Resources.result = true;
                    Resources.msg = "Success";
                    return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
                }

            }
            catch (Exception ex)
            {
                Resources.result = false;
                Resources.msg = ex.ToString();
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
            }

        }
        /// <summary>
        /// 刪除Ticket
        /// </summary>
        /// <param name="TicketKey"></param>
        /// <returns></returns>
        public async Task<IActionResult> delTicket(Guid TicketKey)
        {
            var Resources = new Resources();
            try
            {
                _context.Ticket.Where(e => e.TicketKey == TicketKey).Delete();
                await _context.SaveChangesAsync();
                Resources.result = true;
                Resources.msg = "Delete Success";
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
            }
            catch (Exception ex)
            {
                Resources.result = false;
                Resources.msg = ex.ToString();
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
            }

        }
        /// <summary>
        /// 變更已解決狀態
        /// </summary>
        /// <param name="TicketKey"></param>
        /// <returns></returns>
        public async Task<IActionResult> changeResolve(Guid TicketKey)
        {
            var Resources = new Resources();
            try
            {
                _context.Ticket.Where(e => e.TicketKey == TicketKey).Update(c => new Models.Ticket
                {
                    IsResolve = true,

                });
                await _context.SaveChangesAsync();
                Resources.result = true;
                Resources.msg = "Resolve Success";
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
            }
            catch (Exception ex)
            {
                Resources.result = false;
                Resources.msg = ex.ToString();
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
            }

        }
        /// <summary>
        /// 儲存使用者
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> saveUser(User Data)
        {
            var Resources = new Resources();
            try
            {
                _context.User.Add(new User
                {
                    Userkey = Guid.NewGuid(),
                    UserTypeKey = Data.UserTypeKey,
                    UserName = Data.UserName,
                 
                });
                await _context.SaveChangesAsync();
                Resources.result = true;
                Resources.msg = "Success";
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");

            }
            catch (Exception ex)
            {
                Resources.result = false;
                Resources.msg = ex.ToString();
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Resources), "application/json");
            }

        }

        public class Resources
        {
            public bool result { get; set; }
            public string msg { get; set; }
        }
    }
}
