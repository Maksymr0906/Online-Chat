export interface AddMessageRequest {
    chatId: string;
    userId: string;
    content: string;
    sentTime: Date;
}