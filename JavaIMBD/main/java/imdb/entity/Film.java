package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public String getDirector() {
        return director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

	@Column(nullable = false)
    private String name;

    @Column(nullable = false)
    private String genre    ;

    @Column(nullable = false)
    private String director;

    @Column(nullable = false)
    private int year;

    public Film() {
    }
}
