export interface Chat {
    id: string;
    chatName: string;
    creatorUserId: string;
    createdTime: Date;
    messageIds: string[];
    participantIds: string[];
}