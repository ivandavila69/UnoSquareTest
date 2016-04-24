using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using UnoSquareTest.Logic;
using UnoSquareTest.Models;

namespace UnoSquareTest.Logic
{
    public class BoardGameRepository : IBoardGameRepository, IDisposable
    {
        private List<BoardGame> allBoardGames;
        private XDocument boardGameData;

        public BoardGameRepository()
        {
            allBoardGames = new List<BoardGame>();

            boardGameData = XDocument.Load(HttpContext.Current.Server.MapPath(Constants.BOARD_GAME_REP_XML));
            var boardGamesList = from boardGame in boardGameData.Descendants("BoardGame")
                                 select new BoardGame((int)boardGame.Element("Id"), boardGame.Element("Name").Value,
                                 (int)boardGame.Element("Players"), boardGame.Element("Category").Value,
                                 boardGame.Element("Ages").Value, boardGame.Element("Comments").Value);
            allBoardGames.AddRange(boardGamesList.ToList<BoardGame>());
        }

        public void Add(BoardGame boardGame)
        {
            boardGame.Id = (int)(from b in boardGameData.Descendants("BoardGame") orderby (int)b.Element("Id") descending select (int)b.Element("Id")).FirstOrDefault() + 1;

            boardGameData.Root.Add(new XElement("BoardGame", new XElement("Id", boardGame.Id), new XElement("Name", boardGame.Name),
                new XElement("Players", boardGame.Players), new XElement("Category", boardGame.Category), new XElement("Ages", boardGame.Ages),
                new XElement("Comments", boardGame.Comments)));

            boardGameData.Save(HttpContext.Current.Server.MapPath(Constants.BOARD_GAME_REP_XML));
        }

        public void Delete(int id)
        {
            boardGameData.Root.Elements("BoardGame").Where(i => (int)i.Element("Id") == id).Remove();

            boardGameData.Save(HttpContext.Current.Server.MapPath(Constants.BOARD_GAME_REP_XML));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return allBoardGames;
        }

        public BoardGame GetById(int id)
        {
            return allBoardGames.Find(item => item.Id == id);
        }

        public void Update(BoardGame boardGame)
        {
            XElement node = boardGameData.Root.Elements("BoardGame").Where(i => (int)i.Element("Id") == boardGame.Id).FirstOrDefault();

            node.SetElementValue("Name", boardGame.Name == null ?string.Empty : boardGame.Name );
            node.SetElementValue("Players", boardGame.Players);
            node.SetElementValue("Category", boardGame.Category);
            node.SetElementValue("Ages", boardGame.Ages);
            node.SetElementValue("Comments", boardGame.Comments);

            boardGameData.Save(HttpContext.Current.Server.MapPath(Constants.BOARD_GAME_REP_XML));
        }

    }
}