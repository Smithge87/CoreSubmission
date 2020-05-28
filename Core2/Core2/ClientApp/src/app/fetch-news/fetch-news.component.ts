import { Component, OnInit, Inject } from '@angular/core';
import { HackerNews } from '../_models/HackerNews';
import { HackerNewsService } from '../_services/hackerNews.service';

@Component({
  selector: 'app-fetch-news',
  templateUrl: './fetch-news.component.html',
  styleUrls: ['./fetch-news.component.css'],
})
export class FetchNewsComponent implements OnInit {
  hackerNews: HackerNews[];

  constructor(private hackerNewsService: HackerNewsService) {}

  ngOnInit() {
    this.loadStories();
  }

  loadStories() {
    this.hackerNewsService.getStories().subscribe((stories) =>  {
      this.hackerNews = stories; },
      error => {
        console.log(error);
      });
  }
}
