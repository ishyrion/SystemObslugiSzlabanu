using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemObslugiSzlabanu.Models;

namespace SystemObslugiSzlabanu.Controllers
{
    [Route("api/Plate")]
    [ApiController]
    public class PlateController : Controller
    {
        private readonly AppDbContext _db;

        public PlateController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Plate.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var plateFromDb = await _db.Plate.FirstOrDefaultAsync(u => u.Id == id);
            if (plateFromDb == null)
            {
                return Json(new { success = false, message = "Error! No Record Found" });
            }
            _db.Plate.Remove(plateFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful!" });
        }
    }
}
    
