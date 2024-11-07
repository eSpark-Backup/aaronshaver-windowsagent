using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace eSpark_WindowsFIA
{
    public class Scheduler
    {
        public static IScheduler scheduler;
        public static IJobDetail job;
        public async void Start(DateTime CreationDate, DateTime NextScanDate, String scanPath,bool calcHash,int repeatAfter,int duration,bool reschedule)
        {
            //LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            // Grab the Scheduler instance from the Factory
            StdSchedulerFactory factory = new StdSchedulerFactory();

            scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();

            // define the job and tie it to our HelloJob class
            job = JobBuilder.Create<RunScheduler>()
                .WithIdentity(NextScanDate.ToString(), "eSpark_WindowsFIA_JOB")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(NextScanDate.ToString(), "eSpark_WindowsFIA_Trigger")
                //.StartNow()
                .StartAt(NextScanDate)
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .WithRepeatCount(0)
                    //.RepeatForever()
                    )
                .Build();

            // Tell Quartz to schedule the job using our trigger

            await scheduler.ScheduleJob(job, trigger);

            if(!reschedule)
            {
                ControllerDB controllerDB = new ControllerDB();

                Dictionary<String, String> ScheduledJobRecord = new Dictionary<string, string>();                
                ScheduledJobRecord.Add("ScanPath", scanPath);
                ScheduledJobRecord.Add("CreationDate", CreationDate.ToString()) ;
                ScheduledJobRecord.Add("CalculateHash", calcHash+"");//0=false 1=true
                ScheduledJobRecord.Add("ScannedDate", NextScanDate.ToString());//datetime of nextScan
                ScheduledJobRecord.Add("RepeatAfter", repeatAfter.ToString());//no of days , 0 means noRepeat
                ScheduledJobRecord.Add("duration", duration.ToString());//Daily , Weekly , Monthly
                //ScheduledJobRecord.Add("ActualCompleteDate", duration.ToString());//Daily , Weekly , Monthly
                ScheduledJobRecord.Add("JobCompleted", "0");//Is job Completed , 0 means False=Notyet
                controllerDB.InsertOnlyData("ScheduledQuartzJob", null, ScheduledJobRecord);

            }

        }
    }

    public class RunScheduler : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {


            try
            {
                ControllerDB controllerDB = new ControllerDB();
                DataSet dsTemp = controllerDB.ReadData("ScheduledQuartzJob", " CreationDate='" + context.JobDetail.Key.Name+"'");

                if (dsTemp != null && dsTemp.Tables[0] != null && dsTemp.Tables[0].Rows.Count > 0)
                {
                    String ScanPath = dsTemp.Tables[0].Rows[0]["ScanPath"].ToString();

                    //Form1.IsFSWRunning = true;
                    Form1.CalledByScheduler(ScanPath);
                    


                    // some sleep to show what's happening
                    Task.Delay(TimeSpan.FromSeconds(60));

                    // and last shut down the scheduler when you are ready to close your program
                    Scheduler.scheduler.Shutdown();

                    Dictionary<String, String> ScheduledJobRecord = new Dictionary<string, string>();
                    //ScheduledJobRecord.Add("ScanPath", scanPath);
                    //ScheduledJobRecord.Add("CreationDate", DateTime.UtcNow.ToString());
                    //ScheduledJobRecord.Add("CalculateHash", calcHash.ToString());//0=false 1=true
                    //ScheduledJobRecord.Add("ScannedDate", NextScanDate.ToString());//datetime of nextScan
                    ScheduledJobRecord.Add("ActualCompleteDate", DateTime.UtcNow.ToString());//no of days , 0 means noRepeat
                    ScheduledJobRecord.Add("JobCompleted", "1");//Is job Completed , 0 means False=Notyet
                    controllerDB.UpdateData("ScheduledQuartzJob", " CreationDate=" + context.JobDetail.Key.Name, ScheduledJobRecord);
                }
            }
            catch { }

            return null;
            
        }
    }
}
