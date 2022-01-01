using Disco.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Interfaces
{
    public interface IRepositoryManager
    {
        PostRepository PostRepository { get; }
        SongRepository SongRepository { get; }
        VideoRepository VideoRepository { get; }
    }
}
