using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DvdRental.Data;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace DvdRental.Controllers
{

    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public List<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
    }

    public class FilmType : ObjectGraphType<Film>
    {
        public FilmType()
        {
            Field(x => x.FilmId).Description("Film id");
            Field(x => x.Title).Description("Film description");
            Field<List<Actor>>().Description("Actors");
        }
    }

    public class ActorListType : ObjectGraphType<List<Actor>>
    {
        public ActorListType()
        {
          
        }
    }

    public class ActorType : ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(x => x.ActorId);
            Field(x => x.Name);
        }
    }

    public class FilmQuery : ObjectGraphType
    {
        public FilmQuery(dvdrentalContext dvdContext)
        {
            Field<FilmType>(
                "film",
                resolve: context => dvdContext.Film.Select(f => new Film { FilmId = f.FilmId, Title = f.Title, Actors = f.FilmActor.Select(fa => new Actor { ActorId = fa.ActorId, Name = fa.Actor.FirstName + " " + fa.Actor.LastName }).ToList() }).FirstOrDefault()
                );
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly dvdrentalContext _context;
        public ValuesController(dvdrentalContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ContentResult Get(string query)
        {

            var schema = new Schema { Query = new FilmQuery(_context) };

            var json = schema.Execute(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            });


            return Content(json, "application/json");
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
