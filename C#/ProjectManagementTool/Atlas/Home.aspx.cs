﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Octokit;
using System.Web.UI.DataVisualization.Charting;

public partial class Home : System.Web.UI.Page
{
    protected project activeProject;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if some project is currently active from Session value
        if (Session["ActiveProject"] != null)
        {
            divAlert.Visible = false;
            divHome.Visible = true;
            // Get the active project's data from DB
            try
            {                
                activeProject = Database.GetProjectFromDb(Convert.ToInt32(Session["ActiveProject"]));

                // Pie charts
                InitMainPieChart();
                if (Session["LoggedUserId"] != null)
                {
                    InitUserPieChart();
                }
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
            }
        }
        else
        {            
            // userPieChart.Series.Clear();
            // usersPieChart.Series.Clear();
            divAlert.Visible = true;
            divHome.Visible = false;
        }
        
        if (!IsPostBack && activeProject != null)
        {
            InitProjectHomePage();
        }
    }

    protected void InitUserPieChart()
    {
        var data = Database.GetProjectWorkingHoursForUser(Convert.ToInt32(Session["ActiveProject"]), Convert.ToInt32(Session["LoggedUserId"]));
        
        ChartArea chartArea = new ChartArea("ChartArea");
        userPieChart.ChartAreas.Clear();
        userPieChart.ChartAreas.Add(chartArea);
        userPieChart.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
        userPieChart.Series.Clear();
        //userPieChart.Palette = ChartColorPalette.Chocolate;
        userPieChart.Titles.Add("Hours spent on project by " + Session["LoggedUser"]);
        userPieChart.Series.Add("WorkHours");
        userPieChart.Series["WorkHours"].ChartType = SeriesChartType.Pie;
        DataPoint point;
        userPieChart.Legends.Clear();

        foreach (Task item in data)
        {
            point = new DataPoint(0, item.Duration);
            //point.AxisLabel = item.Text;
            point.IsValueShownAsLabel = true;
            point.IsVisibleInLegend = true;
            point.LegendText = item.Text;
            userPieChart.Series["WorkHours"].Points.Add(point);
            userPieChart.Legends.Add(new Legend(item.Text));
        }
    }

    protected void InitMainPieChart()
    {
        var data = Database.GetProjectWorkingHours(Convert.ToInt32(Session["ActiveProject"]));

        ChartArea chartArea = new ChartArea("ChartArea");
        usersPieChart.ChartAreas.Clear();
        usersPieChart.ChartAreas.Add(chartArea);
        usersPieChart.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
        usersPieChart.Series.Clear();
        //usersPieChart.Palette = ChartColorPalette.Pastel;
        usersPieChart.Titles.Add("Total hours spent on project");
        usersPieChart.Series.Add("WorkHours");
        usersPieChart.Series["WorkHours"].ChartType = SeriesChartType.Pie;
        DataPoint point;
        usersPieChart.Legends.Clear();

        foreach (Task item in data)
        {
            point = new DataPoint(0, item.Duration);
            //point.AxisLabel = item.Text;
            point.IsValueShownAsLabel = true;
            point.IsVisibleInLegend = true;
            point.LegendText = item.Text;
            usersPieChart.Series["WorkHours"].Points.Add(point);
            usersPieChart.Legends.Add(new Legend(item.Text));
        }
    }

    /// <summary>
    /// Initializes home page.
    /// </summary>
    protected void InitProjectHomePage()
    {
        lblProjectName.Text = activeProject.name;
        if (!string.IsNullOrEmpty(activeProject.description))
            lblProjectDesc.Text = activeProject.description;
        if (!string.IsNullOrEmpty(activeProject.github_username) && !string.IsNullOrEmpty(activeProject.github_reponame))
            InitGithub();
    }

    /// <summary>
    /// Initializes stuff from Github (commits etc).
    /// </summary>
    protected async void InitGithub()
    {
        divCommitFeed.InnerHtml = "";
        divLanguages.InnerHtml = "";
        try
        {
            // Commit feed
            List<GitHubCommit> commits = await Github.GetCommits(activeProject.github_username, activeProject.github_reponame);
            if (commits != null && commits.Count > 0)
            {
                foreach (GitHubCommit c in commits)
                {
                    divCommitFeed.InnerHtml += string.Format("<div class='feed-item'><div class='date'>{0}<br/>{1} pushed a commit:</div><div class='text'><a href='{2}'>{3}</a></div></div>",
                                                            c.Commit.Author.Date.DateTime.ToShortDateString(), c.Commit.Author.Name, c.HtmlUrl, c.Commit.Message);
                }
            }

            // Programming languages
            List<RepositoryLanguage> languages = await Github.GetLanguages(activeProject.github_username, activeProject.github_reponame);
            if (languages != null && languages.Count > 0)
            {
                foreach (RepositoryLanguage l in languages)
                {
                    divLanguages.InnerHtml += string.Format("<span class='label label-info' style='margin-right:5px'>{0}</span>", l.Name);
                }
            }
        }
        catch (Exception)
        {
            lblMessages.Text = "Failed loading stuff from Github! Probably API rate limit exceeded for your IP...";
        }
    }
}