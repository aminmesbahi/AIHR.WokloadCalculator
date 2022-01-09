import { Course } from './Course';
export interface HistoryItem {
    id: number;
    courses: Course[];
    startDate: Date;
    endDate: Date;
    suggestedDailyStudyHours: number;
    requestTime: string;
  }
  