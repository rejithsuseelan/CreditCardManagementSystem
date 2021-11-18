/*
 * Fasway - Containerisation.
 * https://fastway.ie/
 *
 * Copyright (c) 2021 Fasway.ie.
 * This file is licensed to Fasway.ie
 */

import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class CHttpClient {
  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly http: HttpClient) {}

  get(url: string, params?: any): Observable<any> {
    return this.http.get<any>(this.apiUrl + url, { params });
  }

  post(url: string, data: any = {}): Observable<any> {
    return this.http.post<any>(this.apiUrl + url, data);
  }
}
