import { CommentModel } from "./comments-model";

export interface NewsModel {
    id: number;
    title: string;
    text: string;
    createdAt: string;
    username: string;
    comments: CommentModel[];
  }