package blog.services;
import blog.models.User;
import java.util.List;

public interface UserService 
{
	List<User> findAll();
	User findById(Long id);
	User findByUsername(String name);
	User create(User user);
	User edit(User user);
	void deleteById(Long id);
	boolean authenticate(String username, String password);
}