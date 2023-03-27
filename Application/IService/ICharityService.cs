﻿using Domain.Model.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface ICharityService
    {
        (IEnumerable<Charity> data, int total) GetList(string? key, int? pageSize, int? page);
        (IEnumerable<Charity> data, int total) GetListHaveMoney(int? pageSize, int? page);
        Charity GetById(int id);
        void Add(string name, string situation, string content, int money, int imageId);
        void Update(int id, string name, string situation, string content, int money, int imageId);
        void Delete(int id);
    }
}