# Link Verification Requirement


When a new link is added (`POST /links`):

- Make a call to the proxy security people's API to check to see if that link is "good".
- They will send back a message that says one of three things:
    1. It is "good" - no problem, list it.
        - return what we are already returning. Save it, return it, ready to go.
    2. It is "blocked" - we know about this, and do not display it. It is banned.
        - return 400 Bad Request with an error message that says this is bad, or whatever.
    3. It is "pending" - e.g. we've never seen this before, we don't currently allow it, but we'll check it out and get back to you.
        - This should NOT show up when they do a `GET /links`.
        - Maybe not return an error, but.... they may want to know what is going on, and have a way to check that status (later it might)
             be approved, or blocked, or whatever.


