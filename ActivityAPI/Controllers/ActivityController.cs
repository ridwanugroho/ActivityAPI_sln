using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using ActivityAPI.Models;

namespace ActivityAPI.Controllers
{
    [Route("/activity")]
    [ApiController]
    public class ActivityController
    {
        private AppDbContex _appDbContex;
        public ActivityController(AppDbContex appDbContex)
        {
            _appDbContex = appDbContex;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> Get()
        {
            return _appDbContex.Activities;
        }

        [HttpGet("{id}")]
        public ActionResult<Activity> Get(int id)
        {
            return _appDbContex.Activities.Find(id);
        }
        
        [HttpPost]
        public ActionResult<Activity> Post([FromBody] Activity activity)
        {
            activity.Status = false;
            activity.CreatedAt = DateTime.Now;
            _appDbContex.Activities.Add(activity);
            _appDbContex.SaveChanges();
            
            return activity;
        }

        [HttpPatch]
        [Route("/activity/update/{id}")]
        public ActionResult<Activity> Update(int id, [FromBody] Activity articleToUpdate)
        {
            var activity = _appDbContex.Activities.Find(id);
            activity.Name = articleToUpdate.Name;
            activity.EditedAt = DateTime.Now;
            _appDbContex.SaveChanges();

            return activity;
        }

        [HttpPatch]
        [Route("/activity/status/{id}")]
        public ActionResult<Activity> Done(int id, [FromBody] Activity articleToUpdate)
        {
            var activity = _appDbContex.Activities.Find(id);
            activity.Status = articleToUpdate.Status;
            activity.EditedAt = DateTime.Now;
            _appDbContex.SaveChanges();

            return activity;
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var activity = _appDbContex.Activities.Find(id);
            _appDbContex.Attach(activity);
            _appDbContex.Remove(activity);
            _appDbContex.SaveChanges();
            
            return $"menghapus aktivitas id ke {id}";
        }
    }
}