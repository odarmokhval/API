using IShop.BusinessLogic.Services;
using IShop.Domain.Models;
using IShop.Filters;
using System;
using System.Linq;
using System.Web.Http;

namespace IShop.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoryService _categoryService
            = new CategoryService();

        //[ShopExeptionFilters]
        [HttpGet]
        public IHttpActionResult GetAll()
        {

            //throw new IndexOutOfRangeException();

            return Ok(_categoryService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Category category) 
        { 
            if(string.IsNullOrEmpty(category.Name))
                return Ok("Can't be empty");
            _categoryService.Add(category);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("search/{param}")]
        public IHttpActionResult Search(string name)
        {
            var categories = _categoryService.GetAll();

            categories = categories.Where(c => c.Name.ToLower().Contains(name)).ToList();

            return Ok(categories);
        }
    }
}
