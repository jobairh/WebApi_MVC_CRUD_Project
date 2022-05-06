using AspWebApi_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspWebApi_Crud.Controllers
{
    public class CrudApiController : ApiController
    {
        web_api_crud_dbEntities db = new web_api_crud_dbEntities();

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //var emp = db.employees.where(model => model.id == e.id).firstordefault();
            //if (emp != null)
            //{
            //    emp.id = e.id;
            //    emp.name = e.name;
            //    emp.gender = e.gender;
            //    emp.age = e.age;
            //    emp.designation = e.designation;
            //    emp.salary = e.salary;
            //    db.savechanges();
            //}
            //else
            //{
            //    return notfound();
            //}
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}
