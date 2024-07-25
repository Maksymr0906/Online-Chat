export interface User {
    id: string;
    userName: string;
    createdChatIds: string[];
    participatingChatIds: string[];
    messageIds: string[];
}