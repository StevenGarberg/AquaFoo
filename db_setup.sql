CREATE TABLE IF NOT EXISTS "Aquariums" (
    "Id" text NOT NULL,
    "OwnerId" text NOT NULL,
    "Version" INT NOT NULL DEFAULT 1,
    "CreatedAt" TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    "UpdatedAt" TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    "Deleted" BOOLEAN NOT NULL,
    "Resource" jsonb NOT NULL,
    CONSTRAINT PK_Aquariums PRIMARY KEY ("Id")
);

CREATE INDEX IF NOT EXISTS IDX_Aquariums_OwnerId ON "Aquariums" USING btree ("OwnerId");