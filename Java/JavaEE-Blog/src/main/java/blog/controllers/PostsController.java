package blog.controllers;

import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.util.HtmlUtils;

import blog.models.Post;
import blog.models.User;
import blog.services.NotificationService;
import blog.services.PostService;
import blog.services.UserService;

@Controller
public class PostsController 
{
    @Autowired
    private PostService postService;
    
    @Autowired
    private UserService userService;
    
    @Autowired
    private NotificationService notifyService;
        
    @Autowired
    private HttpServletRequest request;
    	
	@RequestMapping("/posts")
	public String index(Model model) 
	{
		List<Post> allPosts = postService.findAll();
		model.addAttribute("allPosts", allPosts);
		return "posts/index";
	}
	
	@RequestMapping("/posts/create")
	public String create(Model model) 
	{
		return "posts/create";
	}
	
    @RequestMapping(value = "/posts/create", method = RequestMethod.POST)
    public String create(
    		@RequestParam(value = "title") String title,
    		@RequestParam(value = "content") String content) 
    {
        HttpSession session = request.getSession();  
        // Ei kirjautunut, estetään postin luominen
        if (session.getAttribute("user") == null) {
        	notifyService.addErrorMessage("Log in to create a new post");
        	return "/posts/create";
        }
        else {
        	Post post = new Post();
        	// Escapetaan inputista html-tagit pois
        	post.setTitle(HtmlUtils.htmlEscape(title));
        	post.setBody(HtmlUtils.htmlEscape(content));
        	String username = request.getSession().getAttribute("user").toString();
        	User author = userService.findByUsername(username);
        	post.setAuthor(author);
        	post.setDate(new Date());
        	postService.create(post);
        	return "redirect:/";
        }       
    }
      
    @RequestMapping("/posts/view/{id}")
    public String view(@PathVariable("id") Long id, Model model) {
        Post post = postService.findById(id);
        if (post == null) 
        {
            notifyService.addErrorMessage("Cannot find post #" + id);
            return "redirect:/";
        }
        model.addAttribute("post", post);
        return "posts/view";
    }
    
    @RequestMapping("/posts/delete/{id}")
    public String delete(@PathVariable("id") Long id, Model model) {
        Post post = postService.findById(id);
        if (post == null) 
        {
            notifyService.addErrorMessage("Cannot find post #" + id);
            return "redirect:/posts";
        }
        
        // Ei poisteta muiden posteja
        HttpSession session = request.getSession(false);
        if(session == null || session.getAttribute("user") == null)
        {
        	notifyService.addErrorMessage("Login to delete posts");
            return "redirect:/posts";
        }
        String user = session.getAttribute("user").toString();
        if(!user.equals(post.getAuthor().getUsername()))
        {
        	notifyService.addErrorMessage("Cannot delete posts written by other authors");
            return "redirect:/posts";
        }
        
        notifyService.addInfoMessage("Post deleted");
        postService.deleteById(id);
        return "redirect:/posts";
    }
    
    @RequestMapping("/posts/edit/{id}")
    public String edit(@PathVariable("id") Long id, Model model) {
        Post post = postService.findById(id);
        if (post == null) 
        {
            notifyService.addErrorMessage("Cannot find post #" + id);
            return "redirect:/posts";
        }
        model.addAttribute("post", post);
        return "posts/edit";
    }

    @RequestMapping(value = "/posts/edit/{id}", method = RequestMethod.POST)
    public String edit(
    		@RequestParam(value = "id") Long id,
    		@RequestParam(value = "title") String title,
    		@RequestParam(value = "content") String content) 
    {
        Post post = postService.findById(id);
        if (post == null) 
        {
            notifyService.addErrorMessage("Cannot find post #" + id);
            return "redirect:/posts";
        }
        
        // Ei editoida muiden posteja
        HttpSession session = request.getSession(false);
        if(session == null || session.getAttribute("user") == null)
        {
        	notifyService.addErrorMessage("Login to edit posts");
            return "redirect:/posts";
        }        
        String user = session.getAttribute("user").toString();
        if(!user.equals(post.getAuthor().getUsername()))
        {
        	notifyService.addErrorMessage("Cannot edit posts written by other authors");
            return "redirect:/posts";
        }
        
        post.setTitle(HtmlUtils.htmlEscape(title));
        post.setBody(HtmlUtils.htmlEscape(content));
        postService.edit(post);
        return "redirect:/posts/view/" + id;
    }
}