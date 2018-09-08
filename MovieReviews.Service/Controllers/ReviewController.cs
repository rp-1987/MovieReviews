﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReviews.Domain;
using MovieReviews.Domain.Entities;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace MovieReviews.Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReviewController : ApiController
    {
        

        public async Task<IHttpActionResult> Post(Object obj)
        {
            try
            {
                var jsonString = obj.ToString();
                MovieReview review = JsonConvert.DeserializeObject<MovieReview>(jsonString); 
                RepositoryAdaptor adaptor = new RepositoryAdaptor();
                var message = await adaptor.reviewsRepository.AddMovieReview(review);
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
