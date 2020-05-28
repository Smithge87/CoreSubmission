import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HackerNews } from '../_models/HackerNews';

@Injectable({
  providedIn: 'root',
})
export class HackerNewsService {
  _baseUrl;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getStories(): Observable<HackerNews[]> {
    return this.http.get<HackerNews[]>(this._baseUrl + 'story');
  }
}
