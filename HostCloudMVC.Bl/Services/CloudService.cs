using HostCloudMVC.Bl.Exceptions;
using HostCloudMVC.Bl.ViewModels;
using HostCloudMVC.DAL.Contexts;
using HostCloudMVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.Bl.Services;

public class CloudService
{
    private readonly AppDbContext _context;

    public CloudService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    #region Read
    public List<Cloud> GetAllCloud()
    {
        List<Cloud> clouds = _context.Clouds.ToList();
        return clouds;
    }
    public Cloud GetCloudById(int id)
    {
        Cloud? cloud = _context.Clouds.Find(id);
        if (cloud is null)
        {
            throw new CloudException($"databasada {id} idsine malik data tapilmadi");
        }
        return cloud;
    }
    #endregion

    #region Create
    public void CreateCloud(CloudVM cloudVM)
    {
        Cloud newCloud= new Cloud();
        newCloud.Description = cloudVM.Description;
        newCloud.Name = cloudVM.Name;
        string filename = Path.GetFileNameWithoutExtension(cloudVM.ImgFile.FileName);
        string extension = Path.GetExtension(cloudVM.ImgFile.FileName);
        string resultname=filename + Guid.NewGuid() +extension;
        string uploadedPath = "C:\\Users\\II Novbe\\source\\repos\\HostCloudMVC\\HostCloudMVC.MVC\\wwwroot\\assets\\uploadedImages";

        uploadedPath = Path.Combine(uploadedPath, resultname);
        using FileStream stream = new FileStream(uploadedPath,FileMode.Create);
        cloudVM.ImgFile.CopyTo(stream);
        newCloud.ImgPath=resultname;

        _context.Clouds.Add(newCloud);
        _context.SaveChanges();
    }
    #endregion

    #region Update
    public void UpdateCloud(int id, CloudVM cloudVM)
    {
       
        string filename = Path.GetFileNameWithoutExtension(cloudVM.ImgFile.FileName);
        string extension = Path.GetExtension(cloudVM.ImgFile.FileName);
        string resultname = filename + Guid.NewGuid() + extension;
        string uploadedPath = "C:\\Users\\II Novbe\\source\\repos\\HostCloudMVC\\HostCloudMVC.MVC\\wwwroot\\assets\\uploadedImages";

        uploadedPath = Path.Combine(uploadedPath, resultname);
        using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
        cloudVM.ImgFile.CopyTo(stream);
        
        Cloud? cloud1=_context.Clouds.AsNoTracking().SingleOrDefault(cl =>cl.Id==id);
        cloud1.Description = cloudVM.Description;
        cloud1.Name = cloudVM.Name;
        cloud1.ImgPath=resultname;

        if (cloud1 is not null)
        {
            _context.Clouds.Update(cloud1);
            _context.SaveChanges();
        }
        else
        {
            throw new CloudException($"Databasada {id} idsine malik bir data tapilmadi");
        }
    }
    #endregion

    #region Delete
    public void DeleteCloud(int id)
    {
        Cloud? cloud = _context.Clouds.Find(id);
        if (cloud is null)
        {
            throw new CloudException($"Databsada {id} idsine malik bir data tapilmadi");
        }
        else
        {
            _context.Clouds.Remove(cloud);
            _context.SaveChanges();
        }
    }
    #endregion


}
