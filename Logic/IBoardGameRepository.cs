using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnoSquareTest.Models;

namespace UnoSquareTest.Logic
{
    public interface IBoardGameRepository 
    {
        BoardGame GetById(int id);
        void Add(BoardGame boardGame);
        void Update(BoardGame boardGame);
        void Delete(int id);
        IEnumerable<BoardGame> GetAll();
    }
}