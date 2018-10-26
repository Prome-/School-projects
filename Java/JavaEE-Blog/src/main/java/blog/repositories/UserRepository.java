package blog.repositories;

import blog.models.User;

import java.util.List;
import java.util.stream.Stream;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends JpaRepository<User, Long> 
{
	//  @Query("select a.role from UserRole a, User b where b.userName=?1 and a.userid=b.userId")
	User findByUsername(String username);
}