using MyCircles.BLL;

namespace MyCircles.DAL.Joint_Models
{
    public class UserReportedPost
    {
        public int id { get; set; }
        public int postId { get; set; }
        public int reporterUserId { get; set; }
        public string reporterUsername { get; set; }
        public string reason { get; set; }
        public System.DateTime dateCreated { get; set; }

        public int landmarkType { get; set; }
        public string locaPic { get; set; }
        public string locaName { get; set; }




        public UserReportedPost(ReportedPost reportedPost, User reporterUser)
        {
            this.id = reportedPost.Id;

            if (reportedPost.postId.HasValue)
                this.postId = reportedPost.postId.Value;
            else
                this.postId = -1;

            this.reporterUserId = reportedPost.reporterUserId;
            this.reporterUsername = reporterUser.Username;
            this.reason = reportedPost.reason;
            this.dateCreated = reportedPost.dateCreated;
        }
    }
}