package blog.models;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name = "users")
public class User 
{
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	@Column(nullable = false, length = 30, unique = true, name = "username")
	private String username;
	
	@Column(length = 60, name = "password_hash")
	private String passwordHash;
	
	@Column(length = 100, name = "full_name")
	private String fullName;
	
	@Column(nullable = false, length = 20, name = "role")
	private String role;

	@OneToMany(mappedBy = "author")
	private Set<Post> posts = new HashSet<>();
	
	public String getRole() { return role; }
	public void setRole(String role) { this.role = role; }
    public Long getId() { return id; }
    public void setId(Long id) { this.id = id; }
    public String getUsername() { return username; }
    public void setUsername(String username) { this.username = username; }
    public String getPasswordHash() { return passwordHash; }
    public void setPasswordHash(String passHash) { this.passwordHash = passHash; }
    public String getFullName() { return fullName; }
    public void setFullName(String fullName) { this.fullName = fullName; }
    public Set<Post> getPosts() { return posts; }
    public void setPosts(Set<Post> posts) { this.posts = posts; }
    
    public User() { }
    public User(Long id, String username, String fullName) { 
         this.id = id; 
         this.username = username; 
         this.fullName = fullName;
    }

    @Override
    public String toString() {
        return "User{" + "id=" + id + ", username='" + username + '\'' +
            ", passwordHash='" + passwordHash + '\'' +
            ", fullName='" + fullName + '\'' + '}';
    }
}
