using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnoSquareTest.Logic;
using UnoSquareTest.Models;

namespace UnoSquareTest.Controllers
{
    public class BoardGameController : ApiController
    {
        private IBoardGameRepository boardGameRep = new BoardGameRepository();

        [HttpGet]
        public IEnumerable Get()
        {
            return boardGameRep.GetAll();
        }

        [HttpGet]
        public string Get(int id)
        {
            var boardName = boardGameRep.GetById(id).Name;
            return boardName;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]BoardGame boardGame)
        {
            boardGameRep.Add(boardGame);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public void Put(int id, BoardGame boardGame)
        {
            boardGameRep.Update(boardGame);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            boardGameRep.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
