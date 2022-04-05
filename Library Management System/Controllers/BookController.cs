using Library_Management_System.Data;
using Library_Management_System.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private CatalogueDBContext _dbContextCatalogue;
        public BookController(CatalogueDBContext dbContextCatalogue)
        {
            _dbContextCatalogue = dbContextCatalogue;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var catalogueItems = _dbContextCatalogue.Catalogue.ToList();
                if (catalogueItems.Count == 0)
                {
                    return StatusCode(404, "List is Empty");
                }

                return Ok(catalogueItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error.");
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Model.Catalogue createRequest)
        {
            Data.Catalogue newBookEntry = new Data.Catalogue();
            newBookEntry.Book_ID = createRequest.Book_ID;
            newBookEntry.Book_Name = createRequest.Book_Name;
            newBookEntry.Book_Author = createRequest.Book_Author;
            newBookEntry.Book_Registration = createRequest.Book_Registration;
            newBookEntry.Book_Category = createRequest.Book_Category;
            newBookEntry.Book_Description = createRequest.Book_Description;

            try
            {
                _dbContextCatalogue.Catalogue.Add(newBookEntry);
                _dbContextCatalogue.SaveChanges();

                var catalogueItems = _dbContextCatalogue.Catalogue.ToList();
                return Ok(catalogueItems);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Server Error.");
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Model.Catalogue updateRequest)
        {
            try
            {
                var updateItem = _dbContextCatalogue.Catalogue.FirstOrDefault(a => a.Book_ID == updateRequest.Book_ID);
                if (updateItem == null)
                {
                    return StatusCode(404, "Book does not exist.");
                }

                updateItem.Book_ID = updateRequest.Book_ID;
                updateItem.Book_Name = updateRequest.Book_Name;
                updateItem.Book_Author = updateRequest.Book_Author;
                updateItem.Book_Registration = updateRequest.Book_Registration;
                updateItem.Book_Category = updateRequest.Book_Category;
                updateItem.Book_Description = updateRequest.Book_Description;

                _dbContextCatalogue.Entry(updateItem).State = EntityState.Modified;
                _dbContextCatalogue.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error.");
            }

            var catalogueItems = _dbContextCatalogue.Catalogue.ToList();
            return Ok(catalogueItems);

        }
    }
}
