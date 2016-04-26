using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedditClone.Models;

namespace RedditClone.Controllers
{
    public class RedditPostsController : Controller
    {
        private RedditCloneContext db = new RedditCloneContext();

        // GET: RedditPosts
        public ActionResult Index()
        {
            var AllPosts = db.RedditPosts.ToList();
            AllPosts = AllPosts.OrderByDescending(p => p.UpVotes - p.DownVotes).ToList();
            return View(AllPosts);
        }

        // Post: Vote
        [HttpPost]
        public ActionResult DoVote(int? postId, int? commentId, bool isUp)
        {
            IVoteable item = null;
            if (postId.HasValue)
                item = db.RedditPosts.Find(postId.Value);

            if (commentId.HasValue)
                item = db.Comments.Find(commentId.Value);

            if (item == null)
                return HttpNotFound();

            if (isUp)
                item.UpVotes++;
            else
                item.DownVotes++;

            db.SaveChanges();

            return Content(item.TotalVotes.ToString());
        }


        // GET: RedditPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.RedditPosts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            redditPost.Comments = redditPost.Comments.OrderByDescending(c => c.UpVotes - c.DownVotes).ToList();
            return View(redditPost);
        }

        // GET: RedditPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RedditPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,Title,PostTime,UpVotes,DownVotes,ImageUrl,Body")] RedditPost redditPost)
        {
            if (ModelState.IsValid)
            {
                db.RedditPosts.Add(redditPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(redditPost);
        }

        // POST: RedditPosts/CreateComment
        [HttpPost]
        public ActionResult CreateComment(int id, string author, string body)
        {
            var post = db.RedditPosts.Find(id);
            post.Comments.Add(new Comment { Author = author, Body = body });
            db.SaveChanges();
            return Content("Created!");
        }
        // GET: RedditPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.RedditPosts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // POST: RedditPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,Title,PostTime,UpVotes,DownVotes,ImageUrl,Body")] RedditPost redditPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redditPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(redditPost);
        }

        // GET: RedditPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.RedditPosts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // POST: RedditPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RedditPost redditPost = db.RedditPosts.Find(id);
            db.RedditPosts.Remove(redditPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
