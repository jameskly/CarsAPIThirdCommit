using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarDataAccess;

namespace CarsAPI2ndCommit.Controllers
{
  //public class CarsController : ApiController
  //{
  //  List<Car> cars = new List<Car>();

  //  public CarsController()
  //  {
  //    cars.Add(new Car { Id = 1, Make = "Ford", Model = "Focus", Colour = "Navy", Year = 2019 });
  //    cars.Add(new Car { Id = 2, Make = "Toyota", Model = "Yaris", Colour = "Black", Year = 2018 });
  //    cars.Add(new Car { Id = 3, Make = "Honda", Model = "Civic", Colour = "Silver", Year = 2017 });
  //  }

  //  // GET: api/Cars
  //  public List<Car> Get()
  //  {
  //    return cars; // Use Postman for testing API
  //  }

  //  // GET: api/Cars/5
  //  public Car Get(int id)
  //  {
  //    return cars.Where(x => x.Id == id).FirstOrDefault();  // Use Postman for testing API
  //  }

  //  // POST: api/Cars
  //  public void Post(Car val)
  //  {
  //    cars.Add(val);

  //    // Use Postman software to add new JSON object, eg
  //    /*
  //      { 
  //        Id=4,
  //        Make = "Mazda", 
  //        Model = "Mazda3", 
  //        Colour = "Brown", 
  //        Year = 2016	
  //      }
  //    */
  //  }

  //  // PUT: api/Cars/5
  //  public void Put(int id, [FromBody]string value)
  //  {
  //  }

  //  // DELETE: api/Cars/5
  //  public void Delete(int id)
  //  {
  //    cars.RemoveAt(id);  // Use Postman for testing API
  //  }
  //}


  public class CarsController : ApiController
  {

    public IEnumerable<Car> Get()
    {
      using (CarDBEntities entities = new CarDBEntities())
      {
        return entities.Cars.ToList();
      }
    }

    public Car Get(int id)
    {
      using (CarDBEntities entities = new CarDBEntities())
      {
        return entities.Cars.FirstOrDefault(x => x.ID == id);
      }
    }

    // This method will Add a new car  
    public void POST(Car car)
    {
      using (CarDBEntities entities = new CarDBEntities())
      {
        entities.Cars.Add(car);
        entities.SaveChanges();

        /*
        Postman app to test with JSON snippet:
        {
            "Make": "Peugoet",
            "Model": "3008",
            "Colour": "Black",
            "YearOfManufacturer": 2011
        } 
        */
      }
    }

    // This method will Update a car  
    public void PUT(int id, Car car)
    {
      using (CarDBEntities entities = new CarDBEntities())
      {
        var updateCar = entities.Cars.Find(id);
        updateCar.Make = car.Make;
        updateCar.Model = car.Model;
        updateCar.Colour = car.Colour;
        updateCar.YearOfManufacturer = car.YearOfManufacturer;
        entities.Entry(updateCar).State = System.Data.Entity.EntityState.Modified;
        entities.SaveChanges();

        /*
        Postman app to test with JSON snippet:
        {
            "Make": "Peugoet update",
            "Model": "3008 update",
            "Colour": "Black update",
            "YearOfManufacturer": 2000
        } 
        */
      }
    }

    // This method will Delete a car  
    public string Delete(int id)
    {
      using (CarDBEntities entities = new CarDBEntities())
      {
        var car = entities.Cars.Find(id);
        entities.Cars.Remove(car);
        entities.SaveChanges();
        return string.Format("Car with ID={0} is deleted", id);
      }
    }
  }

}
