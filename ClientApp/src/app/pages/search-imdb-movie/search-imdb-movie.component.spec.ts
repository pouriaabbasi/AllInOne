import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchImdbMovieComponent } from './search-imdb-movie.component';

describe('SearchImdbMovieComponent', () => {
  let component: SearchImdbMovieComponent;
  let fixture: ComponentFixture<SearchImdbMovieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchImdbMovieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchImdbMovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
