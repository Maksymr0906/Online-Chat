export interface Chat {
    id: string;
    chatName: string;
    creatorUserId: string;
    creatorUserName: string;
    createdTime: Date;
    messageIds: string[];
    participantIds: string[];
}