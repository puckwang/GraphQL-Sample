import { FC, useEffect, useState } from "react";

interface Props {
    userId?: number;
}

export const ShowUserForApi: FC<Props> = ({ userId }: Props) => {
    const [userJson, setUserJson] = useState("");

    useEffect(() => {
        fetch(`http://localhost:5227/Api/Users/${userId || ''}`)
            .then(response => response.json())
            .then(json => setUserJson(JSON.stringify(json, null, 4)));
    }, [userId]);

    return (
        <pre>{userJson}</pre>
    );
};
